//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using static H5.Core.dom;
//using static H5.Core.es5;

//namespace System.Net.Http
//{
//    internal sealed partial class BrowserHttpController : IDisposable
//    {
//        //private static readonly HttpRequestOptionsKey<bool> EnableStreamingRequest = new HttpRequestOptionsKey<bool>("WebAssemblyEnableStreamingRequest");
//        //private static readonly HttpRequestOptionsKey<bool> EnableStreamingResponse = new HttpRequestOptionsKey<bool>("WebAssemblyEnableStreamingResponse");
//        //private static readonly HttpRequestOptionsKey<IDictionary<string, object>> FetchOptions = new HttpRequestOptionsKey<IDictionary<string, object>>("WebAssemblyFetchOptions");

//        //private readonly CancellationTokenRegistration _abortRegistration;
//        //private readonly string[] _optionNames;
//        //private readonly object[] _optionValues;
//        private readonly string[] _headerNames;
//        private readonly string[] _headerValues;
//        private readonly string uri;
//        private readonly CancellationToken _cancellationToken;
//        private readonly HttpRequestMessage _request;
//        private bool _isDisposed;

//        public BrowserHttpController(HttpRequestMessage request, bool? allowAutoRedirect, CancellationToken cancellationToken)
//        {
//            if (request == null)
//                throw new ArgumentNullException(nameof(request));
//            if (request.RequestUri == null)
//                throw new ArgumentNullException(nameof(request.RequestUri));

//            _cancellationToken = cancellationToken;
//            _request = request;

//            //JSObject httpController = BrowserHttpInterop.CreateController();
//            //CancellationTokenRegistration abortRegistration = cancellationToken.Register(static s =>
//            //{
//            //    JSObject _httpController = (JSObject)s!;

//            //    if (!_httpController.IsDisposed)
//            //    {
//            //        BrowserHttpInterop.Abort(_httpController);
//            //    }
//            //}, httpController);


//            //_jsController = httpController;
//            //_abortRegistration = abortRegistration;

//            uri = /*request.RequestUri.IsAbsoluteUri ? request.RequestUri.AbsoluteUri :*/ request.RequestUri.ToString();

//            //bool hasFetchOptions = request.Options.TryGetValue(FetchOptions, out IDictionary<string, object> fetchOptions);
//            //int optionCount = 1 + (allowAutoRedirect.HasValue ? 1 : 0) + (hasFetchOptions && fetchOptions != null ? fetchOptions.Count : 0);
//            //int optionIndex = 0;

//            //// note there could be more values for each header name and so this is just name count
//            int headerCount = request.Headers.Count + (request.Content?.Headers.Count ?? 0);

//            //_optionNames = new string[optionCount];
//            //_optionValues = new object[optionCount];

//            //_optionNames[optionIndex] = "method";
//            //_optionValues[optionIndex] = request.Method.Method;
//            //optionIndex++;
//            //if (allowAutoRedirect.HasValue)
//            //{
//            //    _optionNames[optionIndex] = "redirect";
//            //    _optionValues[optionIndex] = allowAutoRedirect.Value ? "follow" : "manual";
//            //    optionIndex++;
//            //}

//            //if (hasFetchOptions && fetchOptions != null)
//            //{
//            //    foreach (KeyValuePair<string, object> item in fetchOptions)
//            //    {
//            //        _optionNames[optionIndex] = item.Key;
//            //        _optionValues[optionIndex] = item.Value;
//            //        optionIndex++;
//            //    }
//            //}

//            var headerNames = new List<string>(headerCount);
//            var headerValues = new List<string>(headerCount);

//            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
//            {
//                foreach (string value in header.Value)
//                {
//                    headerNames.Add(header.Key);
//                    headerValues.Add(value);
//                }
//            }

//            if (request.Content != null)
//            {
//                foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
//                {
//                    foreach (string value in header.Value)
//                    {
//                        headerNames.Add(header.Key);
//                        headerValues.Add(value);
//                    }
//                }
//            }
//            _headerNames = headerNames.ToArray();
//            _headerValues = headerValues.ToArray();
//        }

//        Request CreateFetchRequest()
//        {
//            var stream = _request.Content.ReadAsStream();
//            byte[] bts = new byte[stream.Length];
//            stream.Read(bts, 0, bts.Length);
//            return new Request("", new RequestInit
//            {
//                method = _request.Method.Method,
//                headers = HeadersInit.Create(new[] { _headerNames, _headerValues }),
//                mode = RequestMode.cors,
//                redirect = RequestRedirect.follow,
//                credentials = RequestCredentials.include,
//                body = Int8Array.from((ArrayLike<sbyte>)(object)bts)
//            });
//        }

//        HttpResponseMessage ConvertResponse(Response response)
//        {
//            lock (this)
//            {
//                ThrowIfDisposed();
//                string responseType = response.type;
//                int status = response.status;
//                HttpResponseMessage responseMessage = new HttpResponseMessage((HttpStatusCode)status);
//                responseMessage.RequestMessage = _request;
//                if (responseType == "opaqueredirect")
//                {
//                    // Here we will set the ReasonPhrase so that it can be evaluated later.
//                    // We do not have a status code but this will signal some type of what happened
//                    // after interrogating the status code for success or not i.e. IsSuccessStatusCode
//                    //
//                    // https://developer.mozilla.org/en-US/docs/Web/API/Response/type
//                    // opaqueredirect: The fetch request was made with redirect: "manual".
//                    // The Response's status is 0, headers are empty, body is null and trailer is empty.
//                    responseMessage.SetReasonPhraseWithoutValidation(responseType);
//                }

//                bool streamingResponseEnabled = false;
//                //if (BrowserHttpInterop.SupportsStreamingResponse())
//                //{
//                //    _request.Options.TryGetValue(EnableStreamingResponse, out streamingResponseEnabled);
//                //}

//                responseMessage.Content = streamingResponseEnabled
//                    ? new StreamContent(new BrowserHttpReadStream(this))
//                    : (HttpContent)new BrowserHttpContent(this);

//                response.headers.forEach(() =>
//                {
//                    //responseMessage.Headers.Add();
//                });

//                //BrowserHttpInterop.GetResponseHeaders(_jsController!, responseMessage.Headers, responseMessage.Content.Headers);

//                return responseMessage;
//            } //lock
//        }

//        public async Task<HttpResponseMessage> CallFetch()
//        {
//            CancellationHelper.ThrowIfCancellationRequested(_cancellationToken);
//            //Task fetchPromise;
//            //bool streamingRequestEnabled = false;

//            try
//            {
//                var promise = fetch(CreateFetchRequest());
//                var response = await Task.FromPromise<Response>(promise, null);
//                return ConvertResponse(response);
//            }
//            //catch (Exception ex)
//            //{
//            //    if (ex is JSException jse)
//            //    {
//            //        throw new HttpRequestException(jse.Message, jse);
//            //    }
//            //    throw;
//            //}
//            finally
//            {
//                //writeStream?.Dispose();
//                Dispose(); // will also abort request
//            }
//        }


//        public void ThrowIfDisposed()
//        {
//            lock (this)
//            {
//                if (_isDisposed)
//                    throw new ObjectDisposedException("");
//            } //lock
//        }

//        public void Dispose()
//        {
//            lock (this)
//            {
//                if (_isDisposed)
//                    return;
//                _isDisposed = true;
//            }
//            //_abortRegistration.Dispose();
//            //if (_jsController != null)
//            //{
//            //    if (!_jsController.IsDisposed)
//            //    {
//            //        BrowserHttpInterop.Abort(_jsController);// aborts also response
//            //    }
//            //    _jsController.Dispose();
//            //}
//        }
//    }
//}
