// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Json
{
    public static partial class HttpClientJsonExtensions
    {


        private static Task<object> FromJsonAsyncCore(Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> getMethod, HttpClient client, Uri requestUri, Type type, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCoreImpl<object, (Type, JsonSerializerOptions)>(getMethod, client, requestUri, (stream, innerOptions, cancellation) => JsonSerializer.DeserializeAsync(stream, innerOptions.Item1, innerOptions.Item2 ?? JsonSerializerOptions.Web, cancellation), (type, options), cancellationToken);



        private static Task<TValue> FromJsonAsyncCore<TValue>(Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> getMethod, HttpClient client, Uri requestUri, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCoreImpl<TValue, JsonSerializerOptions>(getMethod, client, requestUri, (stream, innerOptions, cancellation) => JsonSerializer.DeserializeAsync<TValue>(stream, innerOptions ?? JsonSerializerOptions.Web, cancellation), options, cancellationToken);

        private static Task<object> FromJsonAsyncCore(Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> getMethod, HttpClient client, Uri requestUri, Type type, JsonSerializerContext context, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCoreImpl<object, (Type, JsonSerializerContext)>(getMethod, client, requestUri, (stream, options, cancellation) => JsonSerializer.DeserializeAsync(stream, options.Item1, options.Item2, cancellation), (type, context), cancellationToken);

        private static Task<TValue> FromJsonAsyncCore<TValue>(Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> getMethod, HttpClient client, Uri requestUri, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken) =>
            FromJsonAsyncCoreImpl<TValue,  JsonTypeInfo<TValue>>(getMethod, client, requestUri, (stream, options, cancellation) => JsonSerializer.DeserializeAsync(stream, options, cancellation), jsonTypeInfo, cancellationToken);

        private static Task<TValue> FromJsonAsyncCoreImpl<TValue, TJsonOptions>(
            Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> getMethod,
            HttpClient client,
            Uri requestUri,
            Func<Stream, TJsonOptions, CancellationToken, Task<TValue>> deserializeMethod,
            TJsonOptions jsonOptions,
            CancellationToken cancellationToken)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            TimeSpan timeout = client.Timeout;

            // Create the CTS before the initial SendAsync so that the SendAsync counts against the timeout.
            CancellationTokenSource linkedCTS = null;
            if (timeout != TimeSpan.MaxValue)
            {
                linkedCTS = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                linkedCTS.CancelAfter(timeout);
            }

            // We call SendAsync outside of the async Core method to propagate exception even without awaiting the returned task.
            Task<HttpResponseMessage> responseTask;
            try
            {
                // Intentionally using cancellationToken instead of the linked one here as HttpClient will enforce the Timeout on its own for this part
                responseTask = getMethod(client, requestUri, cancellationToken);
            }
            catch
            {
                linkedCTS?.Dispose();
                throw;
            }

            bool usingResponseHeadersRead = !ReferenceEquals(getMethod, s_deleteAsync);

            return Core(client, responseTask, usingResponseHeadersRead, linkedCTS, deserializeMethod, jsonOptions, cancellationToken);

            async Task<TValue> Core(
                HttpClient innerClient,
                Task<HttpResponseMessage> innerResponseTask,
                bool innerUsingResponseHeadersRead,
                CancellationTokenSource innerLinkedCTS,
                Func<Stream, TJsonOptions, CancellationToken, Task<TValue>> innerDeserializeMethod,
                TJsonOptions innerJsonOptions,
                CancellationToken innerCancellationToken)
            {
                HttpResponseMessage response = null;
                Stream readStream = null;
                try
                {
                    response = await innerResponseTask;
                    response.EnsureSuccessStatusCode();

                    try
                    {
                        readStream = await GetHttpResponseStreamAsync(innerClient, response, innerUsingResponseHeadersRead, innerCancellationToken);

                        return await innerDeserializeMethod(readStream, innerJsonOptions, innerLinkedCTS?.Token ?? innerCancellationToken);
                    }
                    catch (OperationCanceledException oce) when ((innerLinkedCTS?.Token.IsCancellationRequested == true) && !innerCancellationToken.IsCancellationRequested)
                    {
                        // Matches how HttpClient throws a timeout exception.
                        string message = "net_http_request_timedout";
#if NET
                        throw new TaskCanceledException(message, new TimeoutException(oce.Message, oce), oce.CancellationToken);
#else
                        throw new TaskCanceledException(message, new TimeoutException(oce.Message, oce));
#endif
                    }
                }
                finally
                {
                    response?.Dispose();
                    readStream?.Dispose();
                    innerLinkedCTS?.Dispose();
                }
            }
        }

        private static Uri CreateUri(string uri) =>
            string.IsNullOrEmpty(uri) ? null : new Uri(uri/*, UriKind.RelativeOrAbsolute*/);

        private static Task<Stream> GetHttpResponseStreamAsync(
            HttpClient client,
            HttpResponseMessage response,
            bool usingResponseHeadersRead,
            CancellationToken cancellationToken)
        {
            Debug.Assert(client.MaxResponseContentBufferSize > 0 & client.MaxResponseContentBufferSize <= int.MaxValue);
            int contentLengthLimit = (int)client.MaxResponseContentBufferSize;

            if (response.Content.Headers.ContentLength is long contentLength && contentLength > contentLengthLimit)
            {
                LengthLimitReadStream.ThrowExceededBufferLimit(contentLengthLimit);
            }

            Task<Stream> task = HttpContentJsonExtensions.GetContentStreamAsync(response.Content, cancellationToken);

            // If ResponseHeadersRead wasn't used, HttpClient will have already buffered the whole response upfront.
            // No need to check the limit again.
            return usingResponseHeadersRead ? GetLengthLimitReadStreamAsync(client, task) : task;
        }

        private static async Task<Stream> GetLengthLimitReadStreamAsync(HttpClient client, Task<Stream> task)
        {
            Stream contentStream = await task;
            return new LengthLimitReadStream(contentStream, (int)client.MaxResponseContentBufferSize);
        }
    }
}
