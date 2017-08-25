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
        public CurrencyAttribute(string fullname, string shortname, string symbol)
        {
            Fullname = fullname;
            Shortname = shortname;
            Symbol = symbol;
        }

        /// <summary>
        /// Shortname for the <see cref="Currency"/>
        /// </summary>
        public string Shortname { get; set; }

        /// <summary>
        /// Fullname for the <see cref="Currency"/>
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Symbol for the <see cref="Currency"/>
        /// </summary>
        public string Symbol { get; set; }
    }
}
