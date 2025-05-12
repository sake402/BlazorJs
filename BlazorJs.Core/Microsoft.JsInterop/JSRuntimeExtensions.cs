// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop
{

    /// <summary>
    /// Extensions for <see cref="IJSRuntime"/>.
    /// </summary>
    public static class JSRuntimeExtensions
    {
        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous invocation operation.</returns>
        public static async Task InvokeVoidAsync(this IJSRuntime jsRuntime, string identifier, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            await jsRuntime.InvokeAsync<IJSVoidResult>(identifier, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// <para>
        /// <see cref="JSRuntime"/> will apply timeouts to this operation based on the value configured in <see cref="JSRuntime.DefaultAsyncTimeout"/>. To dispatch a call with a different timeout, or no timeout,
        /// consider using <see cref="IJSRuntime.InvokeAsync{TValue}(string, CancellationToken, object[])" />.
        /// </para>
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
        public static Task<TValue> InvokeAsync<TValue>(this IJSRuntime jsRuntime, string identifier, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            return jsRuntime.InvokeAsync<TValue>(identifier, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts
        /// (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.
        /// </param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of <typeparamref name="TValue"/> obtained by JSON-deserializing the return value.</returns>
        public static Task<TValue> InvokeAsync<TValue>(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            return jsRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts
        /// (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.
        /// </param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous invocation operation.</returns>
        public static async Task InvokeVoidAsync(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            await jsRuntime.InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous invocation operation.</returns>
        public static async Task<TValue> InvokeAsync<TValue>(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            var cancellationTokenSource = timeout == TimeSpan.MaxValue ? null : new CancellationTokenSource(timeout);
            var cancellationToken = cancellationTokenSource?.Token ?? CancellationToken.None;
            try
            {
                return await jsRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
            }
            finally { cancellationTokenSource?.Dispose(); }
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>window.someScope.someFunction</c>.</param>
        /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous invocation operation.</returns>
        public static async Task InvokeVoidAsync(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            var cancellationTokenSource = timeout == TimeSpan.MaxValue ? null : new CancellationTokenSource(timeout);
            var cancellationToken = cancellationTokenSource?.Token ?? CancellationToken.None;
            try
            {
                await jsRuntime.InvokeAsync<IJSVoidResult>(identifier, cancellationToken, args);
            }
            finally { cancellationTokenSource?.Dispose(); }
        }

        /// <summary>
        /// Invokes the specified JavaScript constructor function asynchronously. The function is invoked with the <c>new</c> operator.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
        public static Task<IJSObjectReference> InvokeNewAsync(this IJSRuntime jsRuntime, string identifier, params object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            return jsRuntime.InvokeNewAsync(identifier, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript constructor function asynchronously. The function is invoked with the <c>new</c> operator.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts
        /// (<see cref="JSRuntime.DefaultAsyncTimeout"/>) from being applied.
        /// </param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
        public static Task<IJSObjectReference> InvokeNewAsync(this IJSRuntime jsRuntime, string identifier, CancellationToken cancellationToken, object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            return jsRuntime.InvokeNewAsync(identifier, cancellationToken, args);
        }

        /// <summary>
        /// Invokes the specified JavaScript constructor function asynchronously. The function is invoked with the <c>new</c> operator.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/>.</param>
        /// <param name="identifier">An identifier for the constructor function to invoke. For example, the value <c>"someScope.SomeClass"</c> will invoke the constructor <c>window.someScope.SomeClass</c>.</param>
        /// <param name="timeout">The duration after which to cancel the async operation. Overrides default timeouts (<see cref="JSRuntime.DefaultAsyncTimeout"/>).</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An <see cref="IJSObjectReference"/> instance that represents the created JS object.</returns>
        public static Task<IJSObjectReference> InvokeNewAsync(this IJSRuntime jsRuntime, string identifier, TimeSpan timeout, object[] args)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(jsRuntime);

            var cancellationTokenSource = timeout == TimeSpan.MaxValue ? null : new CancellationTokenSource(timeout);
            var cancellationToken = cancellationTokenSource?.Token ?? CancellationToken.None;
            try
            {
                return jsRuntime.InvokeNewAsync(identifier, cancellationToken, args);
            }
            finally { cancellationTokenSource?.Dispose(); }
        }
    }
}