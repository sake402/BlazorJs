// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static H5.Core.dom;
using static H5.Core.es5;

namespace System.Net.Http
{
    // **Note** on `Task.ConfigureAwait(continueOnCapturedContext: true)` for the WebAssembly Browser.
    // the JavaScript objects have thread affinity, it is necessary that the continuations run the same thread as the start of the async method.
    internal sealed partial class BrowserHttpHandler : HttpMessageHandler
    {
        private bool _allowAutoRedirect = true;// HttpHandlerDefaults.DefaultAutomaticRedirection;
        // flag to determine if the _allowAutoRedirect was explicitly set or not.
        private bool _isAllowAutoRedirectTouched;

        //        #region PlatformNotSupported
        //#pragma warning disable CA1822
        //        public bool UseCookies
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public CookieContainer CookieContainer
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public DecompressionMethods AutomaticDecompression
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public bool UseProxy
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public IWebProxy? Proxy
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public ICredentials? DefaultProxyCredentials
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public bool PreAuthenticate
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public ICredentials? Credentials
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public int MaxAutomaticRedirections
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public int MaxConnectionsPerServer
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public int MaxResponseHeadersLength
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }

        //        public SslClientAuthenticationOptions SslOptions
        //        {
        //            get => throw new PlatformNotSupportedException();
        //            set => throw new PlatformNotSupportedException();
        //        }
        //#pragma warning restore CA1822
        //        #endregion

        public bool AllowAutoRedirect
        {
            get => _allowAutoRedirect;
            set
            {
                _allowAutoRedirect = value;
                _isAllowAutoRedirectTouched = true;
            }
        }

        //internal ClientCertificateOption ClientCertificateOptions;

        public const bool SupportsAutomaticDecompression = false;
        public const bool SupportsProxy = false;
        public const bool SupportsRedirectConfiguration = true;

        private Dictionary<string, object> _properties;
        public IDictionary<string, object> Properties => _properties = _properties ?? new Dictionary<string, object>();

        protected internal override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException();
        }


        Request CreateFetchRequest(HttpRequestMessage mrequest)
        {
            int headerCount = mrequest.Headers.Count + (mrequest.Content?.Headers.Count ?? 0);
            var headerNames = new List<string>(headerCount);
            var headerValues = new List<string>(headerCount);

            foreach (var header in mrequest.Headers)
            {
                foreach (string value in header.Value)
                {
                    headerNames.Add(header.Key);
                    headerValues.Add(value);
                }
            }

            if (mrequest.Content != null)
            {
                foreach (var header in mrequest.Content.Headers)
                {
                    foreach (string value in header.Value)
                    {
                        headerNames.Add(header.Key);
                        headerValues.Add(value);
                    }
                }
            }

            var stream = mrequest.Content?.ReadAsStream();
            byte[] bts = stream != null ? new byte[stream.Length] : null;
            stream?.Read(bts, 0, bts.Length);
            var init = new RequestInit
            {
                method = mrequest.Method.Method,
                //mode = RequestMode.cors,
                //redirect = RequestRedirect.follow,
                //credentials = RequestCredentials.include,
                //body = bts != null ? Int8Array.from((ArrayLike<sbyte>)(object)bts) : null
            };
            if (headerNames.Count > 0)
            {
                init.headers = HeadersInit.Create(new[] { headerNames.ToArray(), headerValues.ToArray() });
            }
            if (bts != null)
            {
                init.body = Int8Array.from((ArrayLike<sbyte>)(object)bts);
            }
            return new Request(mrequest.RequestUri.ToString(), init);
        }

        HttpResponseMessage ConvertResponse(HttpRequestMessage mrequest, Response mresponse)
        {
            lock (this)
            {
                string responseType = mresponse.type;
                int status = mresponse.status;
                HttpResponseMessage responseMessage = new HttpResponseMessage((HttpStatusCode)status);
                responseMessage.RequestMessage = mrequest;
                if (responseType == "opaqueredirect")
                {
                    // Here we will set the ReasonPhrase so that it can be evaluated later.
                    // We do not have a status code but this will signal some type of what happened
                    // after interrogating the status code for success or not i.e. IsSuccessStatusCode
                    //
                    // https://developer.mozilla.org/en-US/docs/Web/API/Response/type
                    // opaqueredirect: The fetch request was made with redirect: "manual".
                    // The Response's status is 0, headers are empty, body is null and trailer is empty.
                    responseMessage.SetReasonPhraseWithoutValidation(responseType);
                }

                bool streamingResponseEnabled = false;
                //if (BrowserHttpInterop.SupportsStreamingResponse())
                //{
                //    _request.Options.TryGetValue(EnableStreamingResponse, out streamingResponseEnabled);
                //}

                responseMessage.Content = streamingResponseEnabled
                    ? new StreamContent(new BrowserHttpReadStream(mresponse))
                    : (HttpContent)new BrowserHttpContent(mresponse);

                mresponse.headers.forEach(() =>
                {
                    //responseMessage.Headers.Add();
                });

                //BrowserHttpInterop.GetResponseHeaders(_jsController!, responseMessage.Headers, responseMessage.Content.Headers);

                return responseMessage;
            } //lock
        }

        protected internal override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool? allowAutoRedirect = _isAllowAutoRedirectTouched ? AllowAutoRedirect : (bool?)null;

            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.RequestUri == null)
                throw new ArgumentNullException(nameof(request.RequestUri));

            //JSObject httpController = BrowserHttpInterop.CreateController();
            //CancellationTokenRegistration abortRegistration = cancellationToken.Register(static s =>
            //{
            //    JSObject _httpController = (JSObject)s!;

            //    if (!_httpController.IsDisposed)
            //    {
            //        BrowserHttpInterop.Abort(_httpController);
            //    }
            //}, httpController);


            //_jsController = httpController;
            //_abortRegistration = abortRegistration;

            var uri = /*request.RequestUri.IsAbsoluteUri ? request.RequestUri.AbsoluteUri :*/ request.RequestUri.ToString();

            //bool hasFetchOptions = request.Options.TryGetValue(FetchOptions, out IDictionary<string, object> fetchOptions);
            //int optionCount = 1 + (allowAutoRedirect.HasValue ? 1 : 0) + (hasFetchOptions && fetchOptions != null ? fetchOptions.Count : 0);
            //int optionIndex = 0;

            //// note there could be more values for each header name and so this is just name count

            //_optionNames = new string[optionCount];
            //_optionValues = new object[optionCount];

            //_optionNames[optionIndex] = "method";
            //_optionValues[optionIndex] = request.Method.Method;
            //optionIndex++;
            //if (allowAutoRedirect.HasValue)
            //{
            //    _optionNames[optionIndex] = "redirect";
            //    _optionValues[optionIndex] = allowAutoRedirect.Value ? "follow" : "manual";
            //    optionIndex++;
            //}

            //if (hasFetchOptions && fetchOptions != null)
            //{
            //    foreach (KeyValuePair<string, object> item in fetchOptions)
            //    {
            //        _optionNames[optionIndex] = item.Key;
            //        _optionValues[optionIndex] = item.Value;
            //        optionIndex++;
            //    }
            //}

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            //Task fetchPromise;
            //bool streamingRequestEnabled = false;

            try
            {
                var promise = fetch(CreateFetchRequest(request));
                var response = await Task.FromPromise<Response[]>(promise.As<IPromise>(), null);
                return ConvertResponse(request, response[0]);
            }
            //catch (Exception ex)
            //{
            //    if (ex is JSException jse)
            //    {
            //        throw new HttpRequestException(jse.Message, jse);
            //    }
            //    throw;
            //}
            finally
            {
                //writeStream?.Dispose();
                Dispose(); // will also abort request
            }
        }

        internal void ThrowIfDisposed()
        {
        }
    }
}
