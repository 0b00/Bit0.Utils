using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bit0.Utils.Http.Filters
{
    /// <summary>
    /// Check if input is not null
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotEmptyAttribute : DataTypeAttribute
    {
        /// <summary>
        /// Check if input is not null
        /// </summary>
        public NotEmptyAttribute()
            : base("NotNull")
        {
            ErrorMessage = "The {0} list cannot be empty.";
        }

        /// <summary>
        /// Check if value is valid
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return value != null && value is IEnumerable<object> && (value as IEnumerable<object>).Any();
        }
    }
}
