using Bit0.Utils.Common;
using Bit0.Utils.Common.Extensions;
using Xunit;

namespace Bit0.Utils.Tests.Common.Extensions
{
    public class CurrencyExtensionsTests
    {
        [Fact]
        public void Name()
        {
            var str1 = Currency.SEK.GetFullname();
            var str2 = Currency.USD.GetFullname();

            Assert.Equal("Swedish Kroner", str1);
            Assert.Equal("US Dollar", str2);
            Assert.NotEqual("US Dollar", str1);
        }

        [Fact]
        public void Symbol()
        {
            var str1 = Currency.SEK.GetSymbol();
            var str2 = Currency.USD.GetSymbol();

            Assert.Equal("kr", str1);
            Assert.Equal("US$", str2);
            Assert.NotEqual("US$", str1);
        }

        [Fact]
        public void Short()
        {
            var str1 = Currency.SEK.GetShortname();
            var str2 = Currency.USD.GetShortname();

            Assert.Equal("SEK", str1);
            Assert.Equal("USD", str2);
            Assert.NotEqual("USD", str1);
        }

    }
}
