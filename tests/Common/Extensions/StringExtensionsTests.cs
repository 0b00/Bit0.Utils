using System.Collections.Generic;
using System.Linq;
using Bit0.Utils.Common.Attributes;
using Bit0.Utils.Common.Extensions;
using Xunit;

namespace Bit0.Utils.Tests.Common.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToCamelCase()
        {
            var str = "ToCamelCase".ToCamelCase();

            Assert.Equal("toCamelCase", str);
        }

        [Fact]
        public void Contains()
        {
            var list = new List<string>
            {
                "Item1",
                "Item2",
                "Item3",
                "Item4",
            };

            Assert.True(list.Contains("item1", true));
            Assert.True(list.Contains("Item2", true));
        }

        [Fact]
        public void StringValue()
        {
            var str1 = StringTest.Item1.GetValue();
            var str2 = StringTest.Item2.GetValue();

            Assert.Equal("Item1", str1);
            Assert.Equal("Item2", str2);

            Assert.NotEqual("Item2", str1);
        }


        public enum StringTest
        {
            [String("Item1")]
            Item1,

            [String("Item2")]
            Item2
        }
    }
}
