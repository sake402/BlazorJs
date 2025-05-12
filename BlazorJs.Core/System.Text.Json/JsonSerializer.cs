using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using H5;
using BlazorJs.Core;

namespace System.Text.Json
{
    //
    // Summary:
    //     Provides functionality to serialize objects or value types to JSON and to deserialize
    //     JSON into objects or value types.
    public static partial class JsonSerializer
    {
        [Template("JSON.stringify({0})")]
        public extern static string SerializeImpl(object value);
        [Template("JSON.parse({0})")]
        public extern static object DeserializeImpl(string value);

        static void DeepCopy(object source, object destination)
        {
            if (source != null && destination != null)
            {
                var props = object.GetOwnPropertyNames(source);
                var properties = destination.GetType().GetProperties();
                for (int i = 0; i < props.Length; i++)
                {
                    var value = source[props[i]];
                    if (value != null)
                    {
                        var property = properties.SingleOrDefault(p => p.Name.Equals(props[i], StringComparison.InvariantCultureIgnoreCase));
                        if (property != null)
                        {
                            var type = H5.Script.TypeOf(value);
                            if (type == "number" || type == "string")
                            {
                                if (type == "string")
                                    value = ValueConverter.Convert(value, property.PropertyType);
                                property.SetValue(destination, value);
                            }
                            else if (type == "object")
                            {
                                if (H5.Script.IsArray(value))
                                {
                                    Type elementType = property.PropertyType.GetElementType() ?? property.PropertyType.GetGenericArguments()[0];
                                    Array valueArray = value.As<Array>();
                                    Array newArray = Array.CreateInstance(elementType, valueArray.Length);
                                    for (int ii = 0; ii < valueArray.Length; ii++)
                                    {
                                        var obj = Activator.CreateInstance(elementType);
                                        DeepCopy(valueArray[ii], obj);
                                        newArray[ii] = obj;
                                    }
                                    property.SetValue(destination, newArray);
                                }
                                else
                                {
                                    var newObject = Activator.CreateInstance(property.PropertyType);
                                    DeepCopy(value, newObject);
                                    property.SetValue(destination, newObject);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static object Convert(object obj, Type type)
        {
            var newObject = Activator.CreateInstance(type);
            DeepCopy(obj, newObject);
            return newObject;
        }

        static object Convert(string json, Type type)
        {
            var obj = DeserializeImpl(json);
            var jtype = H5.Script.TypeOf(obj);
            if (obj == null || obj.GetType() == type || jtype == "number" || jtype == "string")
                return json;
            return Convert(obj, type);
        }

        static T Convert<T>(string json, Type type = null)
        {
            return (T)Convert(json, type ?? typeof(T));
        }

        static T Convert<T>(object obj, Type type = null)
        {
            return (T)Convert(obj, type ?? typeof(T));
        }


        static async Task<string> AsStringAsync(Stream utf8Json, CancellationToken cancellationToken)
        {
            Span<byte> span = new Span<byte>((int)utf8Json.Length);
            await utf8Json.ReadAsync(span, cancellationToken);
            return Encoding.UTF8.GetString(span.Array);
        }
        static string AsString(Stream utf8Json)
        {
            Span<byte> span = new Span<byte>((int)utf8Json.Length);
            utf8Json.ReadAsync(span, CancellationToken.None).GetAwaiter().GetResult();
            return Encoding.UTF8.GetString(span.Array);
        }

        static string AsString(ReadOnlySpan<byte> span)
        {
            return Encoding.UTF8.GetString(span.ToArray());
        }

        static string AsString(ReadOnlySpan<char> span)
        {
            return span.AsString();
        }

        static string SerializeToString(object o, Type type)
        {
            var str = SerializeImpl(o);
            return str;
        }

        static void SerializeToStream(object o, Stream utf8Json, Type type)
        {
            var str = SerializeImpl(o);
            var bytes = Encoding.UTF8.GetBytes(str);
            utf8Json.Write(bytes, 0, bytes.Length);
        }

        static async Task SerializeToStreamAsync(object o, Stream utf8Json, Type type, CancellationToken cancellationToken)
        {
            var str = SerializeImpl(o);
            var bytes = Encoding.UTF8.GetBytes(str);
            await utf8Json.WriteAsync(bytes, cancellationToken);
        }

        static byte[] SerializeToBytes(object o, Type type)
        {
            var str = SerializeImpl(o);
            return Encoding.UTF8.GetBytes(str);
        }


        public static TValue Deserialize<TValue>(Stream utf8Json, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(AsString(utf8Json));
        }
        public static TValue Deserialize<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(AsString(utf8Json));
        }
        public static TValue Deserialize<TValue>(ReadOnlySpan<byte> utf8Json, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(AsString(utf8Json));
        }
        public static TValue Deserialize<TValue>(ReadOnlySpan<byte> utf8Json, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(AsString(utf8Json));
        }
        public static TValue Deserialize<TValue>(ReadOnlySpan<char> json, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(AsString(json));
        }
        public static TValue Deserialize<TValue>(ReadOnlySpan<char> json, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(AsString(json));
        }
        public static TValue Deserialize<TValue>(string json, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(json);
        }
        public static TValue Deserialize<TValue>(string json, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(json);
        }
        public static object Deserialize(Stream utf8Json, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(AsString(utf8Json), returnType);
        }
        public static object Deserialize(Stream utf8Json, Type returnType, JsonSerializerContext context)
        {
            return Convert(AsString(utf8Json), returnType);
        }
        public static object Deserialize(ReadOnlySpan<byte> utf8Json, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(AsString(utf8Json), jsonTypeInfo.Type);
        }
        public static object Deserialize(ReadOnlySpan<byte> utf8Json, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(AsString(utf8Json), returnType);
        }
        public static object Deserialize(ReadOnlySpan<byte> utf8Json, Type returnType, JsonSerializerContext context)
        {
            return Convert(AsString(utf8Json), returnType);
        }
        public static object Deserialize(ReadOnlySpan<char> json, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(AsString(json), jsonTypeInfo.Type);
        }
        public static object Deserialize(ReadOnlySpan<char> json, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(AsString(json), returnType);
        }
        public static object Deserialize(ReadOnlySpan<char> json, Type returnType, JsonSerializerContext context)
        {
            return Convert(AsString(json), returnType);
        }
        public static object Deserialize(string json, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(json, jsonTypeInfo.Type);
        }
        public static object Deserialize(string json, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(json, returnType);
        }
        public static object Deserialize(string json, Type returnType, JsonSerializerContext context)
        {
            return Convert(json, returnType);
        }
        public static object Deserialize(Stream utf8Json, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(AsString(utf8Json), jsonTypeInfo.Type);
        }
        public static async Task<TValue> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            return Convert<TValue>(await AsStringAsync(utf8Json, cancellationToken));
        }
        public static async Task<object> DeserializeAsync(Stream utf8Json, Type returnType, JsonSerializerContext context, CancellationToken cancellationToken = default)
        {
            return Convert(await AsStringAsync(utf8Json, cancellationToken), returnType);
        }
        public static async Task<object> DeserializeAsync(Stream utf8Json, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken = default)
        {
            return Convert(await AsStringAsync(utf8Json, cancellationToken), jsonTypeInfo.Type);
        }
        public static async Task<TValue> DeserializeAsync<TValue>(Stream utf8Json, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default)
        {
            return Convert<TValue>(await AsStringAsync(utf8Json, cancellationToken), jsonTypeInfo.Type);
        }
        public static async Task<object> DeserializeAsync(Stream utf8Json, Type returnType, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            return Convert(await AsStringAsync(utf8Json, cancellationToken), returnType);
        }

        public static TValue Deserialize<TValue>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(document.Object);
        }

        public static TValue Deserialize<TValue>(this JsonDocument document, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(document.Object);
        }

        public static TValue Deserialize<TValue>(this JsonElement element, JsonSerializerOptions options = null)
        {
            return Convert<TValue>(element.Object);
        }

        public static TValue Deserialize<TValue>(this JsonElement element, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return Convert<TValue>(element.Object);
        }

        public static object Deserialize(this JsonDocument document, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(document.Object, returnType);
        }

        public static object Deserialize(this JsonDocument document, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(document.Object, jsonTypeInfo.Type);
        }

        public static object Deserialize(this JsonElement element, Type returnType, JsonSerializerOptions options = null)
        {
            return Convert(element.Object, returnType);
        }

        public static object Deserialize(this JsonElement element, Type returnType, JsonSerializerContext context)
        {
            return Convert(element.Object, returnType);
        }

        public static object Deserialize(this JsonElement element, JsonTypeInfo jsonTypeInfo)
        {
            return Convert(element.Object, jsonTypeInfo.Type);
        }

        public static object Deserialize(this JsonDocument document, Type returnType, JsonSerializerContext context)
        {
            return Convert(document.Object, returnType);
        }


        public static string Serialize<TValue>(TValue value, JsonSerializerOptions options = null)
        {
            return SerializeToString(value, typeof(TValue));
        }
        public static void Serialize<TValue>(Stream utf8Json, TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            SerializeToStream(value, utf8Json, jsonTypeInfo.Type);
        }
        public static void Serialize<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions options = null)
        {
            SerializeToStream(value, utf8Json, typeof(TValue));
        }
        public static string Serialize(object value, Type inputType, JsonSerializerContext context)
        {
            return SerializeToString(value, inputType);
        }
        public static string Serialize(object value, Type inputType, JsonSerializerOptions options = null)
        {
            return SerializeToString(value, inputType);
        }
        public static string Serialize<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return SerializeToString(value, jsonTypeInfo.Type);
        }
        public static void Serialize(Stream utf8Json, object value, JsonTypeInfo jsonTypeInfo)
        {
            SerializeToStream(value, utf8Json, jsonTypeInfo.Type);
        }
        public static void Serialize(Stream utf8Json, object value, Type inputType, JsonSerializerOptions options = null)
        {
            SerializeToStream(value, utf8Json, inputType);
        }
        public static void Serialize(Stream utf8Json, object value, Type inputType, JsonSerializerContext context)
        {
            SerializeToStream(value, utf8Json, inputType);
        }
        public static string Serialize(object value, JsonTypeInfo jsonTypeInfo)
        {
            return SerializeToString(value, jsonTypeInfo.Type);
        }
        public static Task SerializeAsync(Stream utf8Json, object value, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken = default)
        {
            return SerializeToStreamAsync(value, utf8Json, jsonTypeInfo.Type, cancellationToken);
        }
        public static Task SerializeAsync(Stream utf8Json, object value, Type inputType, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            return SerializeToStreamAsync(value, utf8Json, inputType, cancellationToken);
        }
        public static Task SerializeAsync(Stream utf8Json, object value, Type inputType, JsonSerializerContext context, CancellationToken cancellationToken = default)
        {
            return SerializeToStreamAsync(value, utf8Json, inputType, cancellationToken);
        }
        public static Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            return SerializeToStreamAsync(value, utf8Json, typeof(TValue), cancellationToken);
        }
        public static Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonTypeInfo<TValue> jsonTypeInfo, CancellationToken cancellationToken = default)
        {
            return SerializeToStreamAsync(value, utf8Json, jsonTypeInfo.Type, cancellationToken);
        }
        public static byte[] SerializeToUtf8Bytes<TValue>(TValue value, JsonSerializerOptions options = null)
        {
            return SerializeToBytes(value, typeof(TValue));
        }
        public static byte[] SerializeToUtf8Bytes<TValue>(TValue value, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            return SerializeToBytes(value, jsonTypeInfo.Type);
        }
        public static byte[] SerializeToUtf8Bytes(object value, JsonTypeInfo jsonTypeInfo)
        {
            return SerializeToBytes(value, jsonTypeInfo.Type);
        }
        public static byte[] SerializeToUtf8Bytes(object value, Type inputType, JsonSerializerOptions options = null)
        {
            return SerializeToBytes(value, inputType);
        }
        public static byte[] SerializeToUtf8Bytes(object value, Type inputType, JsonSerializerContext context)
        {
            return SerializeToBytes(value, inputType);
        }
    }

}
