// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace System.Net.Http.Headers
{
    internal sealed partial class TransferCodingHeaderParser : BaseHeaderParser
    {
        private readonly Func<TransferCodingHeaderValue> _transferCodingCreator;

        internal static readonly TransferCodingHeaderParser SingleValueParser =
            new TransferCodingHeaderParser(false, CreateTransferCoding);
        internal static readonly TransferCodingHeaderParser MultipleValueParser =
            new TransferCodingHeaderParser(true, CreateTransferCoding);
        internal static readonly TransferCodingHeaderParser SingleValueWithQualityParser =
            new TransferCodingHeaderParser(false, CreateTransferCodingWithQuality);
        internal static readonly TransferCodingHeaderParser MultipleValueWithQualityParser =
            new TransferCodingHeaderParser(true, CreateTransferCodingWithQuality);

        private TransferCodingHeaderParser(bool supportsMultipleValues,
            Func<TransferCodingHeaderValue> transferCodingCreator)
            : base(supportsMultipleValues)
        {
            Debug.Assert(transferCodingCreator != null);

            _transferCodingCreator = transferCodingCreator;
        }

        protected override int GetParsedValueLength(string value, int startIndex, object storeValue,
            out object parsedValue)
        {
            int resultLength = TransferCodingHeaderValue.GetTransferCodingLength(value, startIndex,
                _transferCodingCreator, out TransferCodingHeaderValue temp);

            parsedValue = temp;
            return resultLength;
        }

        private static TransferCodingHeaderValue CreateTransferCoding() => new TransferCodingHeaderValue();

        private static TransferCodingWithQualityHeaderValue CreateTransferCodingWithQuality() => new TransferCodingWithQualityHeaderValue();
    }
}
