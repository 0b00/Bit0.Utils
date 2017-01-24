using System;
using System.Reflection;

namespace Bit0.Utils.Extensions
{
    /// <summary>
    /// Enum extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get custom attributes applied on enum field values.
        /// </summary>
        /// <typeparam name="T">Custom attribute type</typeparam>
        /// <param name="e">Enum field value</param>
        /// <returns></returns>
        public static T GetFieldAttribute<T>(this Enum e) where T : Attribute
        {
            return e.GetType().GetField(e.ToString()).GetCustomAttribute<T>();
        }
    }
}