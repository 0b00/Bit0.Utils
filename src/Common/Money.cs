using System;

namespace Bit0.Utils.Common
{
    /// <summary>
    /// Money
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Currency
        /// </summary>
        public Currency Currency { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public Double Amount { get; set; }
        /// <summary>
        /// VAT
        /// </summary>
        public Int32 Vat { get; set; }
        /// <summary>
        /// VAT included
        /// </summary>
        public Boolean AmountHasVat { get; set; }
    }
}