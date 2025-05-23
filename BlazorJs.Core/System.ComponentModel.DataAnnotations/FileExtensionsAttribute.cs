﻿using System.Diagnostics.CodeAnalysis;
namespace System.ComponentModel.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed partial class FileExtensionsAttribute : DataTypeAttribute
    {
        private string _extensions;

        public FileExtensionsAttribute()
            : base(DataType.Upload)
        {

            // DevDiv 468241: set DefaultErrorMessage not ErrorMessage, allowing user to set
            // ErrorMessageResourceType and ErrorMessageResourceName to use localized messages.
            DefaultErrorMessage = "FileExtensionsAttribute_Invalid";
        }

        public string Extensions
        {
            get
            {
                // Default file extensions match those from jquery validate.
                return String.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
            }
            set
            {
                _extensions = value;
            }
        }

        private string ExtensionsFormatted
        {
            get
            {
                return ExtensionsParsed.Aggregate((left, right) => left + ", " + right);
            }
        }

        private string ExtensionsNormalized
        {
            get
            {
                return Extensions.Replace(" ", "").Replace(".", "").ToLower();
            }
        }

        private IEnumerable<string> ExtensionsParsed
        {
            get
            {
                return ExtensionsNormalized.Split(',').Select(e => "." + e);
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, ExtensionsFormatted);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string valueAsString = value as string;
            if (valueAsString != null)
            {
                return ValidateExtension(valueAsString);
            }

            return false;
        }

        private bool ValidateExtension(string fileName)
        {
            try
            {
                return ExtensionsParsed.Contains(Path.GetExtension(fileName).ToLower());
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
