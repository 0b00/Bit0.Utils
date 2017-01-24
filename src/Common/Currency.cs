// ReSharper disable InconsistentNaming

using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Common
{
    /// <summary>
    /// List of available currencies for <see cref="Money"/>
    /// </summary>
    public enum Currency
    {
        /// <summary>
        /// Swedish Kroner
        /// </summary>
        [Currency("Swedish Kroner", "kr")]
        SEK,

        /// <summary>
        /// United States Dollar
        /// </summary>
        [Currency("US Dollar", "US$")]
        USD
    }
}