namespace Bit0.Utils.Common.Extensions
{
    /// <summary>
    /// Money extensions
    /// </summary>
    public static class MoneyExtensions
    {
        private static double GetVatValue(Money m)
        {
            return ((100.0 + m.Vat) / 100);
        }

        /// <summary>
        /// Get amount with VAT
        /// </summary>
        /// <param name="m">Money object</param>
        /// <returns></returns>
        public static Money GetAmountInclusiveVat(this Money m)
        {
            return new Money
            {
                Currency = m.Currency,
                Vat = m.Vat,
                Amount = m.AmountHasVat ? m.Amount : m.Amount * GetVatValue(m),
                AmountHasVat = true
            };
        }

        /// <summary>
        /// Get amount without VAT
        /// </summary>
        /// <param name="m">Money object</param>
        /// <returns></returns>
        public static Money GetAmountExclusiveVat(this Money m)
        {
            return new Money
            {
                Currency = m.Currency,
                Vat = m.Vat,
                Amount = !m.AmountHasVat ? m.Amount : m.Amount / GetVatValue(m),
                AmountHasVat = false
            };
        }
    }
}
