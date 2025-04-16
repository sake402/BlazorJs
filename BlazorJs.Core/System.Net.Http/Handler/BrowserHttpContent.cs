// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using static H5.Core.dom;
using static H5.Core.es5;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal sealed partial class BrowserHttpContent : HttpContent
    {
        private byte[] _data;
        private int _length = -1;
        private readonly Response _response;

        public BrowserHttpContent(Response response)
        {
            _response = response;
        }

        private async Task<byte[]> GetResponseData(CancellationToken cancellationToken)
        {
            if (_data != null)
            {
                return _data;
            }
            ArrayBuffer buffer = (await Task.FromPromise<ArrayBuffer[]>(_response.arrayBuffer().As<IPromise>(), null))[0];
            _length = (int)buffer.byteLength;
            _data = new byte[_length];
            return new Uint8Array(buffer).As<byte[]>();
            //return buffer.As<byte[]>();
        }

        protected override async Task<Stream> CreateContentReadStreamAsync()
        {
            byte[] data = await GetResponseData(CancellationToken.None);
            return new MemoryStream(data, writable: false);
        }

        protected override Task SerializeToStreamAsync(Stream stream) =>
            SerializeToStreamAsync(stream, CancellationToken.None);

        protected override async Task SerializeToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            byte[] data = await GetResponseData(cancellationToken);
            await stream.WriteAsync(data, cancellationToken);
        }

        protected internal override bool TryComputeLength(out long length)
        {
            if (_length != -1)
            {
                length = _length;
                return true;
            }

            length = 0;
            return false;
        }
    }
}
