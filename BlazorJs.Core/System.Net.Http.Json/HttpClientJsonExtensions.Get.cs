// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Json
{
    /// <summary>
    /// Contains the extensions methods for using JSON as the content-type in HttpClient.
    /// </summary>
    public static partial class HttpClientJsonExtensions
    {
        private static readonly Func<HttpClient, Uri, CancellationToken, Task<HttpResponseMessage>> s_getAsync =
             (client, uri, cancellation) => client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellation);

        
        
        public static Task<object> GetFromJsonAsync(this HttpClient client, string requestUri, Type type, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync(client, CreateUri(requestUri), type, options, cancellationToken);

        
        
        public static Task<object> GetFromJsonAsync(this HttpClient client, Uri requestUri, Type type, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCore((innerClient, uri, cancellation) => innerClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellation), client, requestUri, type, options, cancellationToken);

        
        
        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, string requestUri, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync<TValue>(client, CreateUri(requestUri), options, cancellationToken);

        
        
        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, Uri requestUri, JsonSerializerOptions options, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCore<TValue>(s_getAsync, client, requestUri, options, cancellationToken);

        public static Task<object> GetFromJsonAsync(this HttpClient client, string requestUri, Type type, JsonSerializerContext context, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync(client, CreateUri(requestUri), type, context, cancellationToken);

        public static Task<object> GetFromJsonAsync(this HttpClient client, Uri requestUri, Type type, JsonSerializerContext context, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCore(s_getAsync, client, requestUri, type, context, cancellationToken);

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, string requestUri, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync(client, CreateUri(requestUri), jsonTypeInfo, cancellationToken);

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, Uri requestUri, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default) =>
            FromJsonAsyncCore(s_getAsync, client, requestUri, jsonTypeInfo, cancellationToken);

        
        
        public static Task<object> GetFromJsonAsync(this HttpClient client, string requestUri, Type type, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync(client, requestUri, type, options: null, cancellationToken);

        
        
        public static Task<object> GetFromJsonAsync(this HttpClient client, Uri requestUri, Type type, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync(client, requestUri, type, options: null, cancellationToken);

        
        
        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, string requestUri, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync<TValue>(client, requestUri, options: null, cancellationToken);

        
        
        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default) =>
            GetFromJsonAsync<TValue>(client, requestUri, options: null, cancellationToken);
    }
}
