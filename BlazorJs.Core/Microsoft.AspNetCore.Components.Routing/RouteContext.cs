//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using System.Buffers;
//using System.Diagnostics.CodeAnalysis;
//using System.Runtime.CompilerServices;
//using System.Text;
//using Microsoft.AspNetCore.Internal;
//using Microsoft.AspNetCore.Routing;

//namespace Microsoft.AspNetCore.Components.Routing
//{
//    internal sealed partial class RouteContext
//    {
//        public RouteContext(string path)
//        {
//            Path = path.Contains('%') ? GetDecodedPath(path) : path;

//            string GetDecodedPath(string path2)
//            {
//                //var uriBuffer = path2.Length < 128 ?
//                //new UriBuffer(new byte[path2.Length]) :
//                //new UriBuffer(path2.Length);
//                try
//                {
//                    var uriBuffer = path2.ToArray();
//                    UriExtension.Decode(uriBuffer, uriBuffer, out int decodedLength);
//                    path2 = new string(uriBuffer, 0, decodedLength);
//                    return path2;

//                    ////var utf8Span = uriBuffer.Buffer;
//                    //if (Encoding.UTF8.TryGetBytes(path2.AsSpan(), utf8Span, out var written))
//                    //{
//                    //    utf8Span = utf8Span[new Range(0, written)];
//                    //    UriExtension.HexUnescape()
//                    //    var decodedLength = UrlDecoder.DecodeInPlace(utf8Span, isFormEncoding: false);
//                    //    utf8Span = utf8Span[new Range(0, decodedLength)];
//                    //    path2 = Encoding.UTF8.GetString(utf8Span.ToArray());
//                    //    return path2;
//                    //}
//                    //return path2;
//                }
//                finally
//                {
//                    //uriBuffer.Dispose();
//                }
//            }
//        }

//        public string Path { get; set; }

//        public RouteValueDictionary RouteValues { get; set; } = new RouteValueDictionary();

//        public InboundRouteEntry Entry { get; set; }

//        public Type Handler => Entry?.Handler;

//        public IReadOnlyDictionary<string, object> Parameters => RouteValues;

//        //private readonly ref struct UriBuffer
//        //{
//        //    private readonly byte[] _pooled;

//        //    public Span<byte> Buffer { get; }

//        //    public UriBuffer(int length)
//        //    {
//        //        _pooled = ArrayPool<byte>.Shared.Rent(length);
//        //        Buffer = _pooled.AsSpan(0, length);
//        //    }

//        //    public UriBuffer(Span<byte> buffer)
//        //    {
//        //        _pooled = null;
//        //        Buffer = buffer;
//        //    }

//        //    public void Dispose()
//        //    {
//        //        if (_pooled != null)
//        //        {
//        //            ArrayPool<byte>.Shared.Return(_pooled);
//        //        }
//        //    }
//        //}
//    }
//}