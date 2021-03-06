﻿using System;
using System.Collections.Generic;
using Bit0.Utils.Common.Attributes;
using System.Linq;

namespace Bit0.Utils.Common.Extensions
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
        public static String GetValue(this Enum s)
        {
            return s.GetFieldAttribute<StringAttribute>().Value;
        }

        /// <summary>
        /// Determines whether the specified list contains the matching string value
        /// 
        /// Snippet from: http://stackoverflow.com/a/10254081
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="value">The value to match.</param>
        /// <param name="ignoreCase">if set to <c>true</c> the case is ignored.</param>
        /// <returns>
        ///   <c>true</c> if the specified list contais the matching string; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean Contains(this IEnumerable<String> list, String value, Boolean ignoreCase = false)
        {
            return ignoreCase ?
                list.Any(s => s.Equals(value, StringComparison.OrdinalIgnoreCase)) :
                list.Contains(value);
        }

        /// <summary>
        /// Convert Pascal to Camel case
        /// </summary>
        /// <param name="str">Pascal case</param>
        /// <param name="invariant"></param>
        /// <returns></returns>
        public static String ToCamelCase(this String str, Boolean invariant = true)
        {
            var chr = invariant ? Char.ToLowerInvariant(str[0]) : Char.ToLower(str[0]);
            str = chr + str.Substring(1);

            return str;
        }
    }
}