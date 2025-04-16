using H5;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace System.Linq.Expressions
{
    public static partial class ExpressionExtensions
    {
        public static Delegate Compile(this LambdaExpression expression)
        {
            var exp = expression.Body;
            Func<object, object> _delegate = (o) => o;
            while (exp != null)
            {
                if (exp is UnaryExpression un)
                {
                    exp = un.Operand;
                }
                else if (exp is MemberExpression mem)
                {
                    var originalDelegate = _delegate;
                    _delegate = (d) =>
                    {
                        var o = originalDelegate(d);
                        return ((PropertyInfo)mem.Member).GetMethod.Invoke(o);
                        //return originalDelegate(d)[mem.Member.Name];
                    };
                    exp = mem.Expression;
                }
                else if (exp is ParameterExpression pem)
                {
                    if (pem.Name != "value")
                    {
                        var originalDelegate = _delegate;
                        _delegate = (d) => originalDelegate(d)[pem.Name];
                    }
                    exp = null;
                }
                else
                {
                    throw new InvalidOperationException("Unimplemented expression type");
                }
            }
            return _delegate;
        }

        public static TDelegate Compile<TDelegate>(this Expression<TDelegate> expression)
        {
            return (TDelegate)(object)Compile((LambdaExpression)expression);
        }

        public static Expression Update(this Expression expression, Expression expression2)
        {
            throw new NotImplementedException();
        }
    }
}
