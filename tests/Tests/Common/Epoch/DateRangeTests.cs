using System;
using Bit0.Utils.Common.Epoch;
using Xunit;
using Xunit.Sdk;

namespace Bit0.Utils.Tests.Common.Epoch
{
    public class DateRangeTests
    {
        private readonly DateRange _range1;
        private readonly DateRange _range2;

        private readonly DateTime _start;
        private readonly DateTime _end;

        public DateRangeTests()
        {

            _start = new DateTime(2017, 4, 1);
            _end = new DateTime(2017, 4, 30);

            _range1 = new DateRange(_start, _end);
            _range2 = new DateRange(DateTime.Now.AddMinutes(-1), DateTime.Now.AddMinutes(1));
        }

        [Fact]
        public void IsBetween()
        {
            var t1 = _range2.IsBetween();
            var t2 = _range1.IsBetween(new DateTime(2017, 4, 30));
            var t2A = _range1.IsBetween(new DateTime(2017, 4, 30), false);
            var t3 = _range1.IsBetween(new DateTime(2017, 5, 1));

            Assert.True(t1);
            Assert.True(t2);
            Assert.False(t2A);
            Assert.False(t3);
        }

        [Fact]
        public void Start()
        {
            Assert.Equal(_start, _range1.Start);
        }

        [Fact]
        public void End()
        {
            Assert.Equal(_end, _range1.End);
        }

        [Fact]
        public void TimeSpan()
        {
            Assert.Equal(_end - _start, _range1.TimeSpan);
        }
    }
}
