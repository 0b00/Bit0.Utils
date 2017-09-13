using Bit0.Utils.Common.Extensions;
using System;
using Xunit;

namespace Bit0.Utils.Tests.Common.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToUtc()
        {
            //2017-04-27T15:59:12.0000000+02:00

            var utc = ((Double) 1493301552).ToUtc();
            var local = ((Double) 1493301552).ToUtc().ToLocalTime();
            var expected = DateTime.ParseExact("2017-04-27T13:59:12.0000000Z", "o", null);


            Assert.Equal(expected.ToUniversalTime(), utc);
            Assert.Equal(expected.ToLocalTime(), local);
            Assert.Equal(expected, local);
        }

        [Fact]
        public void ToUnixEpoch()
        {
            var utc = new DateTime(2017, 4, 27, 13, 59, 12, DateTimeKind.Utc).ToUnixEpoch();

            var expected = 1493301552L;

            Assert.Equal(expected, utc);
        }
    }
}
