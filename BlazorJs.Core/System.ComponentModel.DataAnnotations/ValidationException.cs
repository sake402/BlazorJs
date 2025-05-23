﻿#if !SILVERLIGHT
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
#endif

namespace System.ComponentModel.DataAnnotations {
    /// <summary>
    /// Exception used for validation using <see cref="ValidationAttribute"/>.
    /// </summary>
//#if !SILVERLIGHT
//    [Serializable]
//#endif
    public partial class ValidationException : Exception {
        private ValidationResult _validationResult;

        /// <summary>
        /// Gets the <see>ValidationAttribute</see> instance that triggered this exception.
        /// </summary>
        public ValidationAttribute ValidationAttribute { get; private set; }

        /// <summary>
        /// Gets the <see cref="ValidationResult"/> instance that describes the validation error.
        /// </summary>
        /// <value>
        /// This property will never be null.
        /// </value>
        public ValidationResult ValidationResult {
            get {
                if (this._validationResult == null) {
                    this._validationResult = new ValidationResult(this.Message);
                }
                return this._validationResult;
            }
        }

        /// <summary>
        /// Gets the value that caused the validating attribute to trigger the exception
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Constructor that accepts a structured <see cref="ValidationResult"/> describing the problem.
        /// </summary>
        /// <param name="validationResult">The value describing the validation error</param>
        /// <param name="validatingAttribute">The attribute that triggered this exception</param>
        /// <param name="value">The value that caused the validating attribute to trigger the exception</param>
        public ValidationException(ValidationResult validationResult, ValidationAttribute validatingAttribute, object value)
            : this(validationResult.ErrorMessage, validatingAttribute, value) {
            this._validationResult = validationResult;
        }

        /// <summary>
        /// Constructor that accepts an error message, the failing attribute, and the invalid value.
        /// </summary>
        /// <param name="errorMessage">The localized error message</param>
        /// <param name="validatingAttribute">The attribute that triggered this exception</param>
        /// <param name="value">The value that caused the validating attribute to trigger the exception</param>
        public ValidationException(string errorMessage, ValidationAttribute validatingAttribute, object value)
            : base(errorMessage) {
            this.Value = value;
            this.ValidationAttribute = validatingAttribute;
        }


        // 

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>The long form of this constructor is preferred because it gives better error reporting.</remarks>
        public ValidationException()
            : base() {
        }

        /// <summary>
        /// Constructor that accepts only a localized message
        /// </summary>
        /// <remarks>The long form of this constructor is preferred because it gives better error reporting.</remarks>
        /// <param name="message">The localized message</param>
        public ValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Constructor that accepts a localized message and an inner exception
        /// </summary>
        /// <remarks>The long form of this constructor is preferred because it gives better error reporting</remarks>
        /// <param name="message">The localized error message</param>
        /// <param name="innerException">inner exception</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

//#if !SILVERLIGHT    // Does not have SerializationInfo (it is internal)
//        /// <summary>
//        /// Constructor that takes serialization info
//        /// </summary>
//        /// <param name="info"></param>
//        /// <param name="context"></param>
//        protected ValidationException(SerializationInfo info, StreamingContext context)
//            : base(info, context) { }
//#endif // !SILVERLIGHT
    }
}
