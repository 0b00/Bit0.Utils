using Bit0.Utils.Common;
using Xunit;

namespace Bit0.Utils.Tests.Common
{
    public class MoneyTests
    {
        private readonly Money _money;

        public MoneyTests()
        {
            _money = new Money
            {
                Amount = 100,
                AmountHasVat = false,
                Currency = Currency.SEK,
                Vat = 25
            };
        }

        [Fact]
        public void Tests()
        {
            Assert.Equal(100, _money.Amount);
            Assert.Equal(25, _money.Vat);
            Assert.Equal(Currency.SEK, _money.Currency);
            Assert.False(_money.AmountHasVat);
        }
    }
}
