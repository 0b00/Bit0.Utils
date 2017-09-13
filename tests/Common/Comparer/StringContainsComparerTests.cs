using System;
using Bit0.Utils.Common.Comparer;
using Xunit;

namespace Bit0.Utils.Tests.Common.Comparer
{
    public class StringContainsComparerTests
    {
        private readonly String _str1;
        private readonly String _str2;
        private readonly StringContainsComparer _comparer;

        public StringContainsComparerTests()
        {
            _str1 = "Test";
            _str2 = "Test1";

            _comparer = new StringContainsComparer();
        }

        [Fact]
        public void Equals()
        {
            Assert.True(_comparer.Equals(_str1, "Test"));
            Assert.False(_comparer.Equals(_str1, _str2));
        }

        [Fact]
        public void HashCode()
        {
            Assert.Equal(_str1.GetHashCode(), _comparer.GetHashCode(_str1));
            Assert.Equal(_str2.GetHashCode(), _comparer.GetHashCode(_str2));
        }
    }
}
