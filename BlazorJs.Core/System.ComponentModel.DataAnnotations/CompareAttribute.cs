﻿namespace System.ComponentModel.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public partial class CompareAttribute : ValidationAttribute
    {

        public CompareAttribute(string otherProperty)
            : base("CompareAttribute_MustMatch")
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; private set; }

        public string OtherPropertyDisplayName { get; internal set; }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, OtherPropertyDisplayName ?? OtherProperty);
        }

        public override bool RequiresValidationContext
        {
            get
            {
                return true;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult("CompareAttribute_UnknownProperty" + OtherProperty);
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (!Equals(value, otherPropertyValue))
            {
                if (OtherPropertyDisplayName == null)
                {
                    OtherPropertyDisplayName = GetDisplayNameForProperty(validationContext.ObjectType, OtherProperty);
                }
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }

        private static string GetDisplayNameForProperty(Type containerType, string propertyName)
        {
            //ICustomTypeDescriptor typeDescriptor = GetTypeDescriptor(containerType);
            //PropertyDescriptor property = typeDescriptor.GetProperties().Find(propertyName, true);
            var property = containerType.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("Common_PropertyNotFound");
            }
            IEnumerable<Attribute> attributes = property.GetCustomAttributes().Cast<Attribute>();
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                return display.GetName();
            }
            //DisplayNameAttribute displayName = attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            //if (displayName != null)
            //{
            //    return displayName.DisplayName;
            //}
            return propertyName;
        }

        //private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        //{
        //    return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        //}

    }
}
