using System;
using System.Collections.Generic;
using System.Text;
using Bit0.Utils.Generators;
using Xunit;

namespace Bit0.Utils.Tests.Generators
{
    public class RandomStringTests
    {
        [Theory]
        [InlineData(false, false, true)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        public void Special(Boolean upper, Boolean number, Boolean special)
        {
            Char[] chars;

            var chars1 = "!@#$%^&/?-_=".ToCharArray();
            var chars2 = "0123456789".ToCharArray();
            var chars3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            if (upper)
            {
                chars = chars3;
            }
            else if (number)
            {
                chars = chars2;
            }
            else
            {
                chars = chars1;
            }

            var str = RandomString.Generate(10, upper, number, special);

            Assert.True(str.IndexOfAny(chars) != -1);
        }
    }
}
