using System;
using System.ComponentModel.DataAnnotations;

namespace Bit0.Utils.Http.Filters
{
    /// <summary>
    /// Check if input is not null
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotNullAttribute : DataTypeAttribute
    {
        /// <summary>
        /// Check if input is not null
        /// </summary>
        public NotNullAttribute()
            : base("NotNull")
        {
            ErrorMessage = "The {0} field cannot be empty (or null).";
        }

        /// <summary>
        /// Check if value is valid
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <returns></returns>
        public override Boolean IsValid(Object value)
        {
            return value != null;
        }
    }
}
