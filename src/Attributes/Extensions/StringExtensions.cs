using System;
using Bit0.Utils.Attributes;

namespace Bit0.Utils.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get string value from enum field
        /// </summary>
        /// <param name="s">Enum field value</param>
        /// <returns></returns>
        public static string GetValue(this Enum s)
        {
            return s.GetFieldAttribute<StringAttribute>().Value;
        }
    }
}