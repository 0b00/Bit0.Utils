using Bit0.Utils.Common;
using Bit0.Utils.Common.Extensions;
using Xunit;

namespace Bit0.Utils.Tests.Common.Extensions
{
    public class MoneyExtensionsTests
    {
        private Money _m1;
        private Money _m2;

        public MoneyExtensionsTests()
        {
            _m1 = new Money
            {
                Vat = 4,
                Amount = 100,
                AmountHasVat = false,
                Currency = Currency.SEK
            };

            _m2 = new Money
            {
                Vat = 4,
                Amount = 104,
                AmountHasVat = true,
                Currency = Currency.USD
            };
        }

        [Fact]
        public void CurrencyFact()
        {
            Assert.Equal(Currency.SEK, _m1.Currency);
            Assert.Equal(Currency.USD, _m2.Currency);
        }

        [Fact]
        public void IncVat()
        {
            var m1 = _m1.GetAmountInclusiveVat();
            var m2 = _m2.GetAmountInclusiveVat();

            Assert.Equal(104, m1.Amount);
            Assert.NotEqual(100, m1.Amount);
            Assert.Equal(104, m2.Amount);
        }

        [Fact]
        public void ExcVat()
        {
            var m1 = _m1.GetAmountExclusiveVat();
            var m2 = _m2.GetAmountExclusiveVat();

            Assert.Equal(100, m1.Amount);
            Assert.Equal(100, m2.Amount);
            Assert.NotEqual(104, m2.Amount);
        }
    }
}
