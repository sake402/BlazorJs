// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop.Implementation
{
    /// <summary>
    /// Implements functionality for <see cref="IJSObjectReference"/>.
    /// </summary>
    public class JSObjectReference : IJSObjectReference
    {
        private readonly JSRuntime _jsRuntime;

        internal bool Disposed { get; set; }

        /// <summary>
        /// The unique identifier assigned to this instance.
        /// </summary>
        protected internal long Id { get; }

        /// <summary>
        /// Initializes a new <see cref="JSObjectReference"/> instance.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="JSRuntime"/> used for invoking JS interop calls.</param>
        /// <param name="id">The unique identifier.</param>
        protected internal JSObjectReference(JSRuntime jsRuntime, long id)
        {
            _jsRuntime = jsRuntime;

            Id = id;
        }

        /// <inheritdoc />
        public Task<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.FunctionCall, args);
        }

        /// <inheritdoc />
        public Task<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.FunctionCall, cancellationToken, args);
        }

        /// <inheritdoc />
        public Task<IJSObjectReference> InvokeNewAsync(string identifier, object[] args)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<IJSObjectReference>(Id, identifier, JSCallType.NewCall, args);
        }

        /// <inheritdoc />
        public Task<IJSObjectReference> InvokeNewAsync(string identifier, CancellationToken cancellationToken, object[] args)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<IJSObjectReference>(Id, identifier, JSCallType.NewCall, cancellationToken, args);
        }

        /// <inheritdoc />
        public Task<TValue> GetValueAsync<TValue>(string identifier)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.GetValue, null);
        }

        /// <inheritdoc />
        public Task<TValue> GetValueAsync<TValue>(string identifier, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            return _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.GetValue, null);
        }

        /// <inheritdoc />
        public async Task SetValueAsync<TValue>(string identifier, TValue value)
        {
            ThrowIfDisposed();

            await _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.SetValue, new object[] { value });
        }

        /// <inheritdoc />
        public async Task SetValueAsync<TValue>(string identifier, TValue value, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            await _jsRuntime.InvokeAsync<TValue>(Id, identifier, JSCallType.SetValue, new object[] { value });
        }

        /// <inheritdoc />
        public async virtual void Dispose()
        {
            if (!Disposed)
            {
                Disposed = true;

                await _jsRuntime.InvokeVoidAsync("DotNet.disposeJSObjectReferenceById", Id);
            }
        }

        ///// <inheritdoc />
        //public async Task DisposeAsync()
        //{
        //    if (!Disposed)
        //    {
        //        Disposed = true;

        //        await _jsRuntime.InvokeVoidAsync("DotNet.disposeJSObjectReferenceById", Id);
        //    }
        //}

        /// <inheritdoc />
        protected void ThrowIfDisposed()
        {
            if (Disposed)
                throw new ObjectDisposedException("disposed");
        }
    }
}