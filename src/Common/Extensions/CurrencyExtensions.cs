using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Common.Extensions
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

        /// <summary>
        /// Get <see cref="CurrencyAttribute.Shortname"/>
        /// </summary>
        /// <param name="c"><see cref="Currency"/> field value</param>
        /// <returns></returns>
        public static string GetShortname(this Currency c)
        {
            return c.GetFieldAttribute<CurrencyAttribute>().Shortname;
        }
    }
}
