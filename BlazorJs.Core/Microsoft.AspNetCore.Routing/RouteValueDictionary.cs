//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.

//using System.Collections;
//using System.Diagnostics;
//using System.Diagnostics.CodeAnalysis;
//using System.Runtime.CompilerServices;
//using Microsoft.AspNetCore.Routing;

//namespace Microsoft.AspNetCore.Routing
//{
//    internal partial class RouteValueDictionary : IDictionary<string, object>, IReadOnlyDictionary<string, object>
//    {
//        // 4 is a good default capacity here because that leaves enough space for area/controller/action/id
//        private const int DefaultCapacity = 4;
//        internal KeyValuePair<string, object>[] _arrayStorage;
//        private int _count;

//        /// <summary>
//        /// Creates an empty <see cref="RouteValueDictionary"/>.
//        /// </summary>
//        public RouteValueDictionary()
//        {
//            _arrayStorage = Array.Empty<KeyValuePair<string, object>>();
//        }

//        /// <summary>
//        /// Creates a <see cref="RouteValueDictionary"/> initialized with the specified <paramref name="values"/>.
//        /// </summary>
//        /// <param name="values">A sequence of values to add to the dictionary..</param>
//        public RouteValueDictionary(IEnumerable<KeyValuePair<string, object>> values)
//        {
//            if (!(values is null))
//            {
//                Initialize(values);
//            }
//            else
//            {
//                _arrayStorage = Array.Empty<KeyValuePair<string, object>>();
//            }
//        }

//        private void Initialize(IEnumerable<KeyValuePair<string, string>> stringValueEnumerable)
//        {
//            _arrayStorage = Array.Empty<KeyValuePair<string, object>>();

//            foreach (var kvp in stringValueEnumerable)
//            {
//                Add(kvp.Key, kvp.Value);
//            }
//        }

//        private void Initialize(IEnumerable<KeyValuePair<string, object>> keyValueEnumerable)
//        {
//            _arrayStorage = Array.Empty<KeyValuePair<string, object>>();

//            foreach (var kvp in keyValueEnumerable)
//            {
//                Add(kvp.Key, kvp.Value);
//            }
//        }

//        private void Initialize(RouteValueDictionary dictionary)
//        {
//            var count = dictionary._count;
//            if (count > 0)
//            {
//                var other = dictionary._arrayStorage;
//                var storage = new KeyValuePair<string, object>[count];
//                Array.Copy(other, 0, storage, 0, count);
//                _arrayStorage = storage;
//                _count = count;
//            }
//            else
//            {
//                _arrayStorage = Array.Empty<KeyValuePair<string, object>>();
//            }
//        }

//        /// <inheritdoc />
//        public object this[string key]
//        {
//            get
//            {
//                if (key == null)
//                {
//                    ThrowArgumentNullExceptionForKey();
//                }

//                TryGetValue(key, out var value);
//                return value;
//            }

//            set
//            {
//                if (key == null)
//                {
//                    ThrowArgumentNullExceptionForKey();
//                }

//                // We're calling this here for the side-effect of converting from properties
//                // to array. We need to create the array even if we just set an existing value since
//                // property storage is immutable.
//                EnsureCapacity(_count);

//                var index = FindIndex(key);
//                if (index < 0)
//                {
//                    EnsureCapacity(_count + 1);
//                    _arrayStorage[_count++] = new KeyValuePair<string, object>(key, value);
//                }
//                else
//                {
//                    _arrayStorage[index] = new KeyValuePair<string, object>(key, value);
//                }
//            }
//        }

//        /// <inheritdoc />
//        public int Count => _count;

//        /// <inheritdoc />
//        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => false;

//        /// <inheritdoc />
//        public ICollection<string> Keys
//        {
//            get
//            {
//                EnsureCapacity(_count);

//                var array = _arrayStorage;
//                var keys = new string[_count];
//                for (var i = 0; i < keys.Length; i++)
//                {
//                    keys[i] = array[i].Key;
//                }

//                return keys;
//            }
//        }

//        IEnumerable<string> IReadOnlyDictionary<string, object>.Keys => Keys;

//        /// <inheritdoc />
//        public ICollection<object> Values
//        {
//            get
//            {
//                EnsureCapacity(_count);

//                var array = _arrayStorage;
//                var values = new object[_count];
//                for (var i = 0; i < values.Length; i++)
//                {
//                    values[i] = array[i].Value;
//                }

//                return values;
//            }
//        }

//        IEnumerable<object> IReadOnlyDictionary<string, object>.Values => Values;

//        /// <inheritdoc />
//        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
//        {
//            Add(item.Key, item.Value);
//        }

//        /// <inheritdoc />
//        public void Add(string key, object value)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            EnsureCapacity(_count + 1);

//            if (ContainsKeyArray(key))
//            {
//                throw new ArgumentException($"An element with the key '{key}' already exists in the {nameof(RouteValueDictionary)}.");
//            }

//            _arrayStorage[_count] = new KeyValuePair<string, object>(key, value);
//            _count++;
//        }

//        /// <inheritdoc />
//        public void Clear()
//        {
//            if (_count == 0)
//            {
//                return;
//            }

//            Array.Clear(_arrayStorage, 0, _count);
//            _count = 0;
//        }

//        /// <inheritdoc />
//        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
//        {
//            return TryGetValue(item.Key, out var value) && EqualityComparer<object>.Default.Equals(value, item.Value);
//        }

//        /// <inheritdoc />
//        public bool ContainsKey(string key)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            return ContainsKeyCore(key);
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private bool ContainsKeyCore(string key)
//        {
//            return ContainsKeyArray(key);
//        }

//        /// <inheritdoc />
//        void ICollection<KeyValuePair<string, object>>.CopyTo(
//            KeyValuePair<string, object>[] array,
//            int arrayIndex)
//        {
//            ArgumentNullExceptionExtension.ThrowIfNull(array);

//            if (arrayIndex < 0 || arrayIndex > array.Length || array.Length - arrayIndex < Count)
//            {
//                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
//            }

//            if (Count == 0)
//            {
//                return;
//            }

//            EnsureCapacity(Count);

//            var storage = _arrayStorage;
//            Array.Copy(storage, 0, array, arrayIndex, _count);
//        }

//        /// <inheritdoc />
//        public Enumerator GetEnumerator()
//        {
//            return new Enumerator(this);
//        }

//        /// <inheritdoc />
//        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

//        /// <inheritdoc />
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

//        /// <inheritdoc />
//        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
//        {
//            if (Count == 0)
//            {
//                return false;
//            }

//            Debug.Assert(_arrayStorage != null);

//            EnsureCapacity(Count);

//            var index = FindIndex(item.Key);
//            var array = _arrayStorage;
//            if (index >= 0 && EqualityComparer<object>.Default.Equals(array[index].Value, item.Value))
//            {
//                Array.Copy(array, index + 1, array, index, _count - index);
//                _count--;
//                array[_count] = default;
//                return true;
//            }

//            return false;
//        }

//        /// <inheritdoc />
//        public bool Remove(string key)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            if (Count == 0)
//            {
//                return false;
//            }

//            // Ensure property storage is converted to array storage as we'll be
//            // applying the lookup and removal on the array
//            EnsureCapacity(_count);

//            var index = FindIndex(key);
//            if (index >= 0)
//            {
//                _count--;
//                var array = _arrayStorage;
//                Array.Copy(array, index + 1, array, index, _count - index);
//                array[_count] = default;

//                return true;
//            }

//            return false;
//        }

//        /// <summary>
//        /// Attempts to remove and return the value that has the specified key from the <see cref="RouteValueDictionary"/>.
//        /// </summary>
//        /// <param name="key">The key of the element to remove and return.</param>
//        /// <param name="value">When this method returns, contains the object removed from the <see cref="RouteValueDictionary"/>, or <c>null</c> if key does not exist.</param>
//        /// <returns>
//        /// <c>true</c> if the object was removed successfully; otherwise, <c>false</c>.
//        /// </returns>
//        public bool Remove(string key, out object value)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            if (_count == 0)
//            {
//                value = default;
//                return false;
//            }

//            // Ensure property storage is converted to array storage as we'll be
//            // applying the lookup and removal on the array
//            EnsureCapacity(_count);

//            var index = FindIndex(key);
//            if (index >= 0)
//            {
//                _count--;
//                var array = _arrayStorage;
//                value = array[index].Value;
//                Array.Copy(array, index + 1, array, index, _count - index);
//                array[_count] = default;

//                return true;
//            }

//            value = default;
//            return false;
//        }

//        /// <summary>
//        /// Attempts to the add the provided <paramref name="key"/> and <paramref name="value"/> to the dictionary.
//        /// </summary>
//        /// <param name="key">The key.</param>
//        /// <param name="value">The value.</param>
//        /// <returns>Returns <c>true</c> if the value was added. Returns <c>false</c> if the key was already present.</returns>
//        public bool TryAdd(string key, object value)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            if (ContainsKeyCore(key))
//            {
//                return false;
//            }

//            EnsureCapacity(Count + 1);
//            _arrayStorage[Count] = new KeyValuePair<string, object>(key, value);
//            _count++;
//            return true;
//        }

//        /// <inheritdoc />
//        public bool TryGetValue(string key, out object value)
//        {
//            if (key == null)
//            {
//                ThrowArgumentNullExceptionForKey();
//            }

//            return TryFindItem(key, out value);
//        }

//        private static void ThrowArgumentNullExceptionForKey()
//        {
//            throw new ArgumentNullException("key");
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private void EnsureCapacity(int capacity)
//        {
//            if (_arrayStorage.Length < capacity)
//            {
//                EnsureCapacitySlow(capacity);
//            }
//        }

//        private void EnsureCapacitySlow(int capacity)
//        {
//            if (_arrayStorage.Length < capacity)
//            {
//                capacity = _arrayStorage.Length == 0 ? DefaultCapacity : _arrayStorage.Length * 2;
//                var array = new KeyValuePair<string, object>[capacity];
//                if (_count > 0)
//                {
//                    Array.Copy(_arrayStorage, 0, array, 0, _count);
//                }

//                _arrayStorage = array;
//            }
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private int FindIndex(string key)
//        {
//            // Generally the bounds checking here will be elided by the JIT because this will be called
//            // on the same code path as EnsureCapacity.
//            var array = _arrayStorage;
//            var count = _count;

//            for (var i = 0; i < count; i++)
//            {
//                if (string.Equals(array[i].Key, key, StringComparison.OrdinalIgnoreCase))
//                {
//                    return i;
//                }
//            }

//            return -1;
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private bool TryFindItem(string key, out object value)
//        {
//            var array = _arrayStorage;
//            var count = _count;

//            // Elide bounds check for indexing.
//            if ((uint)count <= (uint)array.Length)
//            {
//                for (var i = 0; i < count; i++)
//                {
//                    if (string.Equals(array[i].Key, key, StringComparison.OrdinalIgnoreCase))
//                    {
//                        value = array[i].Value;
//                        return true;
//                    }
//                }
//            }

//            value = null;
//            return false;
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private bool ContainsKeyArray(string key)
//        {
//            var array = _arrayStorage;
//            var count = _count;

//            // Elide bounds check for indexing.
//            if ((uint)count <= (uint)array.Length)
//            {
//                for (var i = 0; i < count; i++)
//                {
//                    if (string.Equals(array[i].Key, key, StringComparison.OrdinalIgnoreCase))
//                    {
//                        return true;
//                    }
//                }
//            }

//            return false;
//        }

//        /// <inheritdoc />
//        public partial struct Enumerator : IEnumerator<KeyValuePair<string, object>>
//        {
//            private readonly RouteValueDictionary _dictionary;
//            private int _index;

//            /// <summary>
//            /// Instantiates a new enumerator with the values provided in <paramref name="dictionary"/>.
//            /// </summary>
//            /// <param name="dictionary">A <see cref="RouteValueDictionary"/>.</param>
//            public Enumerator(RouteValueDictionary dictionary)
//            {
//                ArgumentNullExceptionExtension.ThrowIfNull(dictionary);

//                _dictionary = dictionary;

//                Current = default;
//                _index = 0;
//            }

//            /// <inheritdoc />
//            public KeyValuePair<string, object> Current { get; private set; }

//            object IEnumerator.Current => Current;

//            /// <summary>
//            /// Releases resources used by the <see cref="Enumerator"/>.
//            /// </summary>
//            public void Dispose()
//            {
//            }

//            // Similar to the design of List<T>.Enumerator - Split into fast path and slow path for inlining friendliness
//            /// <inheritdoc />
//            [MethodImpl(MethodImplOptions.AggressiveInlining)]
//            public bool MoveNext()
//            {
//                var dictionary = _dictionary;

//                if (((uint)_index < (uint)dictionary._count))
//                {
//                    Current = dictionary._arrayStorage[_index];
//                    _index++;
//                    return true;
//                }
//                return MoveNextRare();
//            }

//            private bool MoveNextRare()
//            {
//                var dictionary = _dictionary;
//                _index = dictionary._count;
//                Current = default;
//                return false;
//            }

//            /// <inheritdoc />
//            public void Reset()
//            {
//                Current = default;
//                _index = 0;
//            }
//        }
//    }
//}