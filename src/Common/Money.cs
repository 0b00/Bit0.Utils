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
        public double Amount { get; set; }
        /// <summary>
        /// VAT
        /// </summary>
        public int Vat { get; set; }
        /// <summary>
        /// VAT included
        /// </summary>
        public bool AmountHasVat { get; set; }
    }
}