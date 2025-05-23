// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.Forms
{
    internal partial interface IInputFileJsCallbacks
    {
        Task NotifyChange(BrowserFile[] files);
    }
}