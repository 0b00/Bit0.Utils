﻿using System;
using Bit0.Utils.Common.Epoch;
using Xunit;

namespace Bit0.Utils.Tests.Common.Epoch
{
    public class DateRangeTests
    {
        [Fact]
        public void Check()
        {
            var range = new DateRange(new DateTime(2017, 4, 1), new DateTime(2017, 4, 30));

            var t1 = range.IsBetween();
            var t2 = range.IsBetween(new DateTime(2017, 4, 30));
            var t2a = range.IsBetween(new DateTime(2017, 4, 30), false);
            var t3 = range.IsBetween(new DateTime(2017, 5, 1));

            Assert.True(t1);
            Assert.True(t2);
            Assert.False(t2a);
            Assert.False(t3);
        }
    }
}