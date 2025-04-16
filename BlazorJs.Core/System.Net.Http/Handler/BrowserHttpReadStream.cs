// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using static H5.Core.dom;
using System.IO;

namespace System.Net.Http
{
    internal sealed partial class BrowserHttpReadStream : Stream
    {
        private Response _response; // we own the object and have to dispose it

        public BrowserHttpReadStream(Response response)
        {
            _response = response;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
            //_response.blob().
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;

        public override void Flush()
        {
        }

        #region PlatformNotSupported

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override long Length => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
