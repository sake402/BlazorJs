﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations {
    /// <summary>
    /// An attribute used to specify the filtering behavior for a column.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed partial class FilterUIHintAttribute : Attribute {
        private UIHintAttribute.UIHintImplementation _implementation;

        /// <summary>
        /// Gets the name of the control that is most appropriate for this associated property or field
        /// </summary>
        public string FilterUIHint {
            get {
                return this._implementation.UIHint;
            }
        }

        /// <summary>
        /// Gets the name of the presentation layer that supports the control type in <see cref="FilterUIHint"/>
        /// </summary>
        public string PresentationLayer {
            get {
                return this._implementation.PresentationLayer;
            }
        }

        /// <summary>
        /// Gets the name-value pairs used as parameters to the control's constructor
        /// </summary>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is ill-formed.</exception>
        public IDictionary<string, object> ControlParameters {
            get {
                return this._implementation.ControlParameters;
            }
        }

//#if !SILVERLIGHT
//        /// <summary>
//        /// Gets a unique identifier for this attribute.
//        /// </summary>
//        public override object TypeId {
//            get {
//                return this;
//            }
//        }
//#endif

        /// <summary>
        /// Constructor that accepts the name of the control, without specifying which presentation layer to use
        /// </summary>
        /// <param name="filterUIHint">The name of the UI control.</param>
        public FilterUIHintAttribute(string filterUIHint)
            : this(filterUIHint, null, new object[0]) {
        }

        /// <summary>
        /// Constructor that accepts both the name of the control as well as the presentation layer
        /// </summary>
        /// <param name="filterUIHint">The name of the control to use</param>
        /// <param name="presentationLayer">The name of the presentation layer that supports this control</param>
        public FilterUIHintAttribute(string filterUIHint, string presentationLayer)
            : this(filterUIHint, presentationLayer, new object[0]) {
        }

        /// <summary>
        /// Full constructor that accepts the name of the control, presentation layer, and optional parameters
        /// to use when constructing the control
        /// </summary>
        /// <param name="filterUIHint">The name of the control</param>
        /// <param name="presentationLayer">The presentation layer</param>
        /// <param name="controlParameters">The list of parameters for the control</param>
        public FilterUIHintAttribute(string filterUIHint, string presentationLayer, params object[] controlParameters) {
            this._implementation = new UIHintAttribute.UIHintImplementation(filterUIHint, presentationLayer, controlParameters);
        }

        /// <summary>
        /// Returns the hash code for this FilterUIHintAttribute.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() {
            return this._implementation.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance of FilterUIHintAttribute and a specified object,
        /// which must also be a FilterUIHintAttribute object, have the same value.
        /// </summary>
        /// <param name="obj">An System.Object.</param>
        /// <returns>true if obj is a FilterUIHintAttribute and its value is the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj) {
            var otherAttribute = obj as FilterUIHintAttribute;
            if (otherAttribute == null) {
                return false;
            }
            return this._implementation.Equals(otherAttribute._implementation);
        }
    }
}
