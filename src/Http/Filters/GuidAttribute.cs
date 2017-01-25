using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bit0.Utils.Http.Filters
{
    /// <summary>
    /// Validate value as Guid
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GuidAttribute : DataTypeAttribute
    {
        private readonly bool _hasList;

        /// <summary>
        /// Validate value as Guid
        /// </summary>
        /// <param name="hasList">Part of a list?</param>
        public GuidAttribute(bool hasList = false)
            : base("Guid")
        {
            _hasList = hasList;

            ErrorMessage = "The {0} field is not a valid Guid.";
        }

        /// <summary>
        /// Check if value is valid
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            Guid guid;

            return !_hasList
                ? Guid.TryParse(value.ToString(), out guid)
                : ((List<string>)value).Aggregate(true, (current, str) => current && Guid.TryParse(str, out guid));
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    Guid guid;
        //    return Guid.TryParse(value.ToString(), out guid)
        //        ? ValidationResult.Success
        //        : new ValidationResult("Not a valid Guid.");
        //}

        //public override string FormatErrorMessage(string name)
        //{
        //    return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        //}
    }
}
