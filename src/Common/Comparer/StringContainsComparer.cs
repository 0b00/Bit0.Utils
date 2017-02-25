using System;
using System.Collections.Generic;

namespace Bit0.Utils.Common.Comparer
{
    /// <summary>
    /// String comparer for Linq
    /// </summary>
    public class StringContainsComparer : IEqualityComparer<string>
    {
        /// <summary>
        /// Check if string are equal, ignoring case
        /// </summary>
        /// <param name="str1">String 1</param>
        /// <param name="str2">String 2</param>
        /// <returns>Tre if str1 and str2 are equal, else false</returns>
        public bool Equals(string str1, string str2)
        {
            return str1.ToLowerInvariant().Equals(str2.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns the hah code of string
        /// </summary>
        /// <param name="str">String to get hash code of</param>
        /// <returns>String hashcode</returns>
        public int GetHashCode(string str)
        {
            return str.GetHashCode();
        }
    }
}
