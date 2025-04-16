//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//namespace Microsoft.AspNetCore.Components.Routing
//{
//    // This is very similar to Microsoft.Extensions.Primitives.StringValues, except it works in terms
//    // of ReadOnlySpan<char> rather than string, so the querystring handling logic doesn't need to
//    // allocate per-value when tracking things that will be parsed as value types.
//    internal partial struct StringSegmentAccumulator
//    {
//        private int count;
//        private ReadOnlySpan<char> _single;
//        private List<ReadOnlySpan<char>> _multiple;

//        public ReadOnlySpan<char> this[int index]
//        {
//            get
//            {
//                if (index >= count)
//                    throw new ArgumentOutOfRangeException();
//                return count == 1 ? _single : _multiple[index];
//            }
//        }

//        public int Count => count;

//        public void SetSingle(ReadOnlySpan<char> value)
//        {
//            _single = value;

//            if (count != 1)
//            {
//                if (count > 1)
//                {
//                    _multiple = null;
//                }

//                count = 1;
//            }
//        }

//        public void Add(ReadOnlySpan<char> value)
//        {
//            switch (count++)
//            {
//                case 0:
//                    _single = value;
//                    break;
//                case 1:
//                    _multiple = new List<ReadOnlySpan<char>>();
//                    _multiple.Add(_single);
//                    _multiple.Add(value);
//                    _single = default;
//                    break;
//                default:
//                    _multiple.Add(value);
//                    break;
//            }
//        }
//    }
//}