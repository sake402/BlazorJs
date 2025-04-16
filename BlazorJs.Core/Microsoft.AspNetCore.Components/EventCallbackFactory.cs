using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// A factory for creating <see cref="EventCallback"/> and <see cref="EventCallback{T}"/>
    /// instances.
    /// </summary>
    public sealed partial class EventCallbackFactory
    {
        /// <summary>
        /// Returns the provided <paramref name="callback"/>. For internal framework use only.
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public EventCallback Create(object receiver, EventCallback callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return callback;
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback Create(object receiver, Action callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback Create(object receiver, Action<object> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback Create(object receiver, Func<Task> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback Create(object receiver, Func<object, Task> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore(receiver, callback);
        }

        /// <summary>
        /// Returns the provided <paramref name="callback"/>. For internal framework use only.
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public EventCallback<TValue> Create<TValue>(object receiver, EventCallback callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);
            throw new NotImplementedException();
            //return new EventCallback<TValue>(callback.Receiver, callback.Delegate);
        }

        /// <summary>
        /// Returns the provided <paramref name="callback"/>. For internal framework use only.
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public EventCallback<TValue> Create<TValue>(object receiver, EventCallback<TValue> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return callback;
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback<TValue> Create<TValue>(object receiver, Action callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore<TValue>(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback<TValue> Create<TValue>(object receiver, Action<TValue> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore<TValue>(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback<TValue> Create<TValue>(object receiver, Func<Task> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore<TValue>(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="receiver">The event receiver.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="EventCallback"/>.</returns>
        public EventCallback<TValue> Create<TValue>(object receiver, Func<TValue, Task> callback)
        {
            ArgumentNullExceptionExtension.ThrowIfNull(receiver);

            return CreateCore<TValue>(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>. For internal framework use only.
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public EventCallback<TValue> CreateInferred<TValue>(object receiver, Action<TValue> callback, TValue value)
        {
            return Create(receiver, callback);
        }

        /// <summary>
        /// Creates an <see cref="EventCallback"/> for the provided <paramref name="receiver"/> and
        /// <paramref name="callback"/>. For internal framework use only.
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public EventCallback<TValue> CreateInferred<TValue>(object receiver, Func<TValue, Task> callback, TValue value)
        {
            return Create(receiver, callback);
        }

        private static EventCallback CreateCore(object receiver, Action callback)
        {
            return new EventCallback(new EventCallback<object>(receiver, callback, EventCallbackDelegateType.Action, EventCallbackFlags.None));
        }

        private static EventCallback CreateCore(object receiver, Action<object> callback)
        {
            return new EventCallback(new EventCallback<object>(receiver, callback, EventCallbackDelegateType.ActionT, EventCallbackFlags.None));
        }

        private static EventCallback CreateCore(object receiver, Func<Task> callback)
        {
            return new EventCallback(new EventCallback<object>(receiver, callback, EventCallbackDelegateType.FuncTask, EventCallbackFlags.None));
        }

        private static EventCallback CreateCore(object receiver, Func<object, Task> callback)
        {
            return new EventCallback(new EventCallback<object>(receiver, callback, EventCallbackDelegateType.FuncTTask, EventCallbackFlags.None));
        }

        private static EventCallback<TValue> CreateCore<TValue>(object receiver, Action callback)
        {
            return new EventCallback<TValue>(receiver, callback, EventCallbackDelegateType.Action, EventCallbackFlags.None);
        }

        private static EventCallback<TValue> CreateCore<TValue>(object receiver, Func<Task> callback)
        {
            return new EventCallback<TValue>(receiver, callback, EventCallbackDelegateType.FuncTask, EventCallbackFlags.None);
        }

        private static EventCallback<TValue> CreateCore<TValue>(object receiver, Action<TValue> callback)
        {
            return new EventCallback<TValue>(receiver, callback, EventCallbackDelegateType.ActionT, EventCallbackFlags.None);
        }

        private static EventCallback<TValue> CreateCore<TValue>(object receiver, Func<TValue, Task> callback)
        {
            return new EventCallback<TValue>(receiver, callback, EventCallbackDelegateType.FuncTTask, EventCallbackFlags.None);
        }

        public EventCallback Create(object receiver, Action action, EventCallbackFlags eventFlags = EventCallbackFlags.None)
        {
            return new EventCallback(new EventCallback<object>(receiver, action, EventCallbackDelegateType.Action, eventFlags));
        }

        public EventCallback Create(object receiver, Func<Task> action, EventCallbackFlags eventFlags = EventCallbackFlags.None)
        {
            return new EventCallback(new EventCallback<object>(receiver, action, EventCallbackDelegateType.FuncTask, eventFlags));
        }

        public EventCallback<T> Create<T>(object receiver, Action<T> action, EventCallbackFlags eventFlags = EventCallbackFlags.None)
        {
            return new EventCallback<T>(receiver, action, eventFlags);
        }

        public static EventCallback<T> Create<T>(object receiver, Func<T, Task> action, EventCallbackFlags eventFlags = EventCallbackFlags.None)
        {
            return new EventCallback<T>(receiver, action, eventFlags);
        }
    }
}
