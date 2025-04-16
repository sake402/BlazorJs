using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.AspNetCore.Components.Forms
{
    internal static partial class ExpressionFormatter
    {
        static ExpressionFormatter()
        {
            //HotReloadManager.Default.OnDeltaApplied += ClearCache;
        }

        internal const int StackAllocBufferSize = 128;

        private delegate void CapturedValueFormatter(object closure, ref ReverseStringBuilder builder);

        private static readonly Dictionary<MemberInfo, CapturedValueFormatter> s_capturedValueFormatterCache = new Dictionary<MemberInfo, CapturedValueFormatter>();
        private static readonly Dictionary<MethodInfo, MethodInfoData> s_methodInfoDataCache = new Dictionary<MethodInfo, MethodInfoData>();

        public static void ClearCache()
        {
            s_capturedValueFormatterCache.Clear();
            s_methodInfoDataCache.Clear();
        }

        public static string FormatLambda(LambdaExpression expression)
        {
            return FormatLambda(expression, prefix: null);
        }

        public static string FormatLambda(LambdaExpression expression, string prefix = null)
        {
            var builder = new ReverseStringBuilder(new char[StackAllocBufferSize]);
            var node = expression.Body;
            var wasLastExpressionMemberAccess = false;
            var wasLastExpressionIndexer = false;

            while (!(node is null))
            {
                switch (node.NodeType)
                {
                    case ExpressionType.Constant:
                        var constantExpression = (ConstantExpression)node;
                        node = null;
                        break;
                    case ExpressionType.Call:
                        var methodCallExpression = (MethodCallExpression)node;

                        if (!IsSingleArgumentIndexer(methodCallExpression))
                        {
                            throw new InvalidOperationException("Method calls cannot be formatted.");
                        }

                        node = methodCallExpression.Object;
                        if (prefix != null && node is ConstantExpression)
                        {
                            break;
                        }

                        if (wasLastExpressionMemberAccess)
                        {
                            wasLastExpressionMemberAccess = false;
                            builder.InsertFront(".");
                        }
                        wasLastExpressionIndexer = true;

                        builder.InsertFront("]");
                        FormatIndexArgument(methodCallExpression.Arguments[0], ref builder);
                        builder.InsertFront("[");

                        break;

                    case ExpressionType.ArrayIndex:
                        var binaryExpression = (BinaryExpression)node;
                        node = binaryExpression.Left;
                        if (prefix != null && node is ConstantExpression)
                        {
                            break;
                        }

                        if (wasLastExpressionMemberAccess)
                        {
                            wasLastExpressionMemberAccess = false;
                            builder.InsertFront(".");
                        }

                        builder.InsertFront("]");
                        FormatIndexArgument(binaryExpression.Right, ref builder);
                        builder.InsertFront("[");
                        wasLastExpressionIndexer = true;
                        break;

                    case ExpressionType.MemberAccess:
                        var memberExpression = (MemberExpression)node;
                        node = memberExpression.Expression;
                        if (prefix != null && node is ConstantExpression)
                        {
                            break;
                        }

                        if (wasLastExpressionMemberAccess)
                        {
                            builder.InsertFront(".");
                        }
                        wasLastExpressionMemberAccess = true;
                        wasLastExpressionIndexer = false;

                        var name = memberExpression.Member.GetCustomAttribute<DataMemberAttribute>()?.Name ?? memberExpression.Member.Name;
                        builder.InsertFront(name);

                        break;

                    default:
                        // Unsupported expression type.
                        node = null;
                        break;
                }
            }

            if (prefix != null)
            {
                if (!builder.Empty && !wasLastExpressionIndexer)
                {
                    builder.InsertFront(".");
                }
                builder.InsertFront(prefix);
            }

            var result = builder.ToString();

            builder.Dispose();

            return result;
        }

        internal static bool IsSingleArgumentIndexer(Expression expression)
        {
            if (!(expression is MethodCallExpression methodExpression) || methodExpression.Arguments.Count != 1)
            {
                return false;
            }

            var methodInfoData = GetOrCreateMethodInfoData(methodExpression.Method);
            return methodInfoData.IsSingleArgumentIndexer;
        }

        private static MethodInfoData GetOrCreateMethodInfoData(MethodInfo methodInfo)
        {
            if (!s_methodInfoDataCache.TryGetValue(methodInfo, out var methodInfoData))
            {
                methodInfoData = GetMethodInfoData(methodInfo);
                s_methodInfoDataCache[methodInfo] = methodInfoData;
            }

            return methodInfoData;

            MethodInfoData GetMethodInfoData(MethodInfo iMethodInfo)
            {
                var declaringType = iMethodInfo.DeclaringType;
                if (declaringType is null)
                {
                    return new MethodInfoData(isSingleArgumentIndexer: false);
                }

                // Check whether GetDefaultMembers() (if present in CoreCLR) would return a member of this type. Compiler
                // names the indexer property, if any, in a generated [DefaultMember] attribute for the containing type.
                //var defaultMember = declaringType.GetCustomAttribute<DefaultMemberAttribute>(inherit: true);
                //if (defaultMember is null)
                //{
                return new MethodInfoData(isSingleArgumentIndexer: false);
                //}

                //// Find default property (the indexer) and confirm its getter is the method in this expression.
                //var runtimeProperties = declaringType.GetRuntimeProperties();
                //if (runtimeProperties is null)
                //{
                //    return new MethodInfoData(isSingleArgumentIndexer: false);
                //}

                //foreach (var property in runtimeProperties)
                //{
                //    if (string.Equals(defaultMember.MemberName, property.Name, StringComparison.Ordinal) &&
                //        property.GetMethod == iMethodInfo)
                //    {
                //        return new MethodInfoData(isSingleArgumentIndexer: true);
                //    }
                //}

                //return new MethodInfoData(isSingleArgumentIndexer: false);
            }
        }

        private static void FormatIndexArgument(
            Expression indexExpression,
            ref ReverseStringBuilder builder)
        {
            switch (indexExpression)
            {
                case MemberExpression memberExpression when memberExpression.Expression is ConstantExpression constantExpression:
                    FormatCapturedValue(memberExpression, constantExpression, ref builder);
                    break;
                case ConstantExpression constantExpression2:
                    FormatConstantValue(constantExpression2, ref builder);
                    break;
                default:
                    throw new InvalidOperationException($"Unable to evaluate index expressions of type '{indexExpression.GetType().Name}'.");
            }
        }

        internal static string FormatIndexArgument(
            Expression indexExpression)
        {
            var builder = new ReverseStringBuilder(new char[StackAllocBufferSize]);
            try
            {
                FormatIndexArgument(indexExpression, ref builder);
                var result = builder.ToString();
                return result;
            }
            finally
            {
                builder.Dispose();
            }
        }

        private static void FormatCapturedValue(MemberExpression memberExpression, ConstantExpression constantExpression, ref ReverseStringBuilder builder)
        {
            var member = memberExpression.Member;
            if (!s_capturedValueFormatterCache.TryGetValue(member, out var format))
            {
                format = CreateCapturedValueFormatter(memberExpression);
                s_capturedValueFormatterCache[member] = format;
            }

            format(constantExpression.Value, ref builder);
        }

        static Func<object, TResult> CompileMemberEvaluator<TResult>(MemberExpression imemberExpression)
        {
            var parameterExpression = Expression.Parameter(typeof(object));
            var convertExpression = Expression.Convert(parameterExpression, imemberExpression.Member.DeclaringType);
            var replacedMemberExpression = imemberExpression.Update(convertExpression);
            var replacedExpression = Expression.Lambda<Func<object, TResult>>(replacedMemberExpression, parameterExpression);
            return replacedExpression.Compile();
        }

        private static CapturedValueFormatter CreateCapturedValueFormatter(MemberExpression memberExpression)
        {
            var memberType = memberExpression.Type;

            if (memberType == typeof(int))
            {
                var func = CompileMemberEvaluator<int>(memberExpression);
                return (object closure, ref ReverseStringBuilder builder) => builder.InsertFront(func.Invoke(closure));
            }
            else if (memberType == typeof(string))
            {
                var func = CompileMemberEvaluator<string>(memberExpression);
                return (object closure, ref ReverseStringBuilder builder) => builder.InsertFront(func.Invoke(closure));
            }
            //else if (typeof(ISpanFormattable).IsAssignableFrom(memberType))
            //{
            //    var func = CompileMemberEvaluator<ISpanFormattable>(memberExpression);
            //    return (object closure, ref ReverseStringBuilder builder) => builder.InsertFront(func.Invoke(closure));
            //}
            else if (typeof(IFormattable).IsAssignableFrom(memberType))
            {
                var func = CompileMemberEvaluator<IFormattable>(memberExpression);
                return (object closure, ref ReverseStringBuilder builder) => builder.InsertFront(func.Invoke(closure));
            }
            else
            {
                throw new InvalidOperationException($"Cannot format an index argument of type '{memberType}'.");
            }
        }

        private static void FormatConstantValue(ConstantExpression constantExpression, ref ReverseStringBuilder builder)
        {
            switch (constantExpression.Value)
            {
                case string s:
                    builder.InsertFront(s);
                    break;
                //case ISpanFormattable spanFormattable:
                //    // This is better than the formattable case because we don't allocate an extra string.
                //    builder.InsertFront(spanFormattable);
                //    break;
                case IFormattable formattable:
                    builder.InsertFront(formattable);
                    break;
                case null:
                    builder.InsertFront("null");
                    break;
                    //case var x:
                    //throw new InvalidOperationException($"Unable to format constant values of type '{x.GetType()}'.");
            }
        }

        private readonly partial struct MethodInfoData
        {
            public bool IsSingleArgumentIndexer { get; }

            public MethodInfoData(bool isSingleArgumentIndexer)
            {
                IsSingleArgumentIndexer = isSingleArgumentIndexer;
            }
        }
    }
}
