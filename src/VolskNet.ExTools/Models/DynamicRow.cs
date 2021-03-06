﻿namespace VolskSoft.ExTools
{
    using System.Collections.Generic;
    using System.Dynamic;

    public sealed class DynamicRow : DynamicObject
    {
        public DynamicRow(Dictionary<string, object> properties)
        {
            Properties = properties;
        }

        public Dictionary<string, object> Properties { get; }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return Properties.Keys;
        }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)
        /// </returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (Properties.ContainsKey(binder.Name))
            {
                result = Properties[binder.Name];
                return true;
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Provides the implementation for operations that set member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as setting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member to which the value is being assigned. For example, for the statement sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="value">The value to set to the member. For example, for sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, the <paramref name="value" /> is "Test".</param>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a language-specific run-time exception is thrown.)
        /// </returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!Properties.ContainsKey(binder.Name))
            {
                return false;
            }

            Properties[binder.Name] = value;
            return true;
        }

        /// <summary>
        /// Tries the get member.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public bool TryGetMember(string fieldName, out object result)
        {
            if (Properties.ContainsKey(fieldName))
            {
                result = Properties[fieldName];
                return true;
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Tries the set member.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool TrySetMember(string fieldName, object value)
        {
            if (!Properties.ContainsKey(fieldName))
            {
                return false;
            }

            Properties[fieldName] = value;

            return true;
        }
    }
}