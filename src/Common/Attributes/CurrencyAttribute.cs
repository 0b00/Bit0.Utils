using System;

namespace Bit0.Utils.Common.Attributes
{
    /// <summary>
    /// Add meta data to <see cref="Currency"/> enum fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class CurrencyAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of <see cref="CurrencyAttribute"/> class
        /// </summary>
        /// <param name="fullname">Fullname for the <see cref="Currency"/></param>
        /// <param name="shortname">Shortname for the <see cref="Currency"/></param>
        /// <param name="symbol">Symbol for the <see cref="Currency"/></param>
        public CurrencyAttribute(String fullname, String shortname, String symbol)
        {
            Fullname = fullname;
            Shortname = shortname;
            Symbol = symbol;
        }

        /// <summary>
        /// Shortname for the <see cref="Currency"/>
        /// </summary>
        public String Shortname { get; set; }

        /// <summary>
        /// Fullname for the <see cref="Currency"/>
        /// </summary>
        public String Fullname { get; set; }

        /// <summary>
        /// Symbol for the <see cref="Currency"/>
        /// </summary>
        public String Symbol { get; set; }
    }
}
