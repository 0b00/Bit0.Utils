using Bit0.Utils;
using Bit0.Utils.Extensions;
using SmartOrder.Attributes;

namespace SmartOrder.Extensions
{
    /// <summary>
    /// Currency extensions
    /// </summary>
    public static class CurrencyExtensions
    {
        /// <summary>
        /// Get <see cref="CurrencyAttribute.Fullname"/>
        /// </summary>
        /// <param name="c"><see cref="Currency"/> field value</param>
        /// <returns></returns>
        public static string GetFullname(this Currency c)
        {
            return c.GetFieldAttribute<CurrencyAttribute>().Fullname;
        }

        /// <summary>
        /// Get <see cref="CurrencyAttribute.Symbol"/>
        /// </summary>
        /// <param name="c"><see cref="Currency"/> field value</param>
        /// <returns></returns>
        public static string GetSymbol(this Currency c)
        {
            return c.GetFieldAttribute<CurrencyAttribute>().Symbol;
        }
    }
}
