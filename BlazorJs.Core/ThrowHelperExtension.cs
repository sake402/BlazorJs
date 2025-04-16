using System;

namespace BlazorJs.Core
{
    internal static partial class ThrowHelperExtension
    {
        //
        // Summary:
        //     Throws an System.ArgumentNullException if argument is null.
        //
        // Parameters:
        //   argument:
        //     The reference type argument to validate as non-null.
        //
        //   paramName:
        //     The name of the parameter with which argument corresponds.
        internal static void ThrowIfNull(this object argument, /*[CallerArgumentExpression("argument")]*/ string paramName = null)
        {
            if (argument == null)
            {
                Throw(paramName);
            }
        }

        private static void Throw(this string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        //
        // Summary:
        //     Throws either an System.ArgumentNullException or an System.ArgumentException
        //     if the specified string is null or whitespace respectively.
        //
        // Parameters:
        //   argument:
        //     String to be checked for null or whitespace.
        //
        //   paramName:
        //     The name of the parameter being checked.
        //
        // Returns:
        //     The original value of argument.
        public static string IfNullOrWhitespace(string argument,/* [CallerArgumentExpression("argument")]*/ string paramName = "")
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(paramName);
                }

                throw new ArgumentException(paramName, "Argument is whitespace");
            }

            return argument;
        }
    }
}
