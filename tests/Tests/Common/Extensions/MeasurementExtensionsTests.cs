using Bit0.Utils.Common;
using Bit0.Utils.Common.Extensions;
using System;
using Xunit;

namespace Bit0.Utils.Tests.Common.Extensions
{
    public class MeasurementExtensionsTests
    {
        [Fact]
        public void NormalizedValueTest1()
        {
            var m = new Measurement
            {
                Unit = MeasurementUnit.CentiLiter,
                Value = 5
            }.GetNormalizedValue();

            Assert.Equal(0.05, m.Value);
            Assert.Equal(MeasurementUnit.Liter, m.Unit);
        }

        [Fact]
        public void NormalizedValueTest2()
        {
            var m = new Measurement
            {
                Unit = MeasurementUnit.KiloMeter,
                Value = 3
            }.GetNormalizedValue();

            Assert.Equal(3000, m.Value);
            Assert.Equal(MeasurementUnit.Meter, m.Unit);
        }

        [Fact]
        public void NormalizedValueTest3()
        {
            var m = new Measurement
            {
                Unit = MeasurementUnit.Meter,
                Value = 3
            }.GetNormalizedValue();

            Assert.Equal(3, m.Value);
            Assert.Equal(MeasurementUnit.Meter, m.Unit);
        }

        [Theory]
        [InlineData("l", MeasurementUnit.Liter)]
        [InlineData("dl", MeasurementUnit.DeciLiter)]
        [InlineData("cl", MeasurementUnit.CentiLiter)]
        [InlineData("ml", MeasurementUnit.MiliLiter)]
        [InlineData("kg", MeasurementUnit.KiloGram)]
        [InlineData("hg", MeasurementUnit.HactoGram)]
        [InlineData("g", MeasurementUnit.Gram)]
        [InlineData("m", MeasurementUnit.Meter)]
        [InlineData("km", MeasurementUnit.KiloMeter)]
        [InlineData("dm", MeasurementUnit.DeciMeter)]
        [InlineData("cm", MeasurementUnit.CentiMeter)]
        [InlineData("mm", MeasurementUnit.MiliMeter)]
        [InlineData("pcs", MeasurementUnit.Piece)]
        [InlineData("boxes", MeasurementUnit.Boxes)]
        public void ShortNameValueTest(String expected, MeasurementUnit unit)
        {
            Assert.Equal(expected, unit.GetShortname());
        }

        [Theory]
        [InlineData(1d, MeasurementUnit.Liter)]
        [InlineData(1d / 10, MeasurementUnit.DeciLiter)]
        [InlineData(1d / 100, MeasurementUnit.CentiLiter)]
        [InlineData(1d / 1000, MeasurementUnit.MiliLiter)]
        [InlineData(1d, MeasurementUnit.KiloGram)]
        [InlineData(1d / 10, MeasurementUnit.HactoGram)]
        [InlineData(1d / 1000, MeasurementUnit.Gram)]
        [InlineData(1d, MeasurementUnit.Meter)]
        [InlineData(1000d, MeasurementUnit.KiloMeter)]
        [InlineData(1d / 10, MeasurementUnit.DeciMeter)]
        [InlineData(1d / 100, MeasurementUnit.CentiMeter)]
        [InlineData(1d / 1000, MeasurementUnit.MiliMeter)]
        [InlineData(1d, MeasurementUnit.Piece)]
        [InlineData(1d, MeasurementUnit.Boxes)]
        public void AttributeConversionFactor(Double expected, MeasurementUnit unit)
        {
            Assert.Equal(expected, unit.GetConversionFactor());
        }

        [Theory]
        [InlineData(MeasurementUnit.None, MeasurementUnit.Liter)]
        [InlineData(MeasurementUnit.Liter, MeasurementUnit.DeciLiter)]
        [InlineData(MeasurementUnit.Liter, MeasurementUnit.CentiLiter)]
        [InlineData(MeasurementUnit.Liter, MeasurementUnit.MiliLiter)]
        [InlineData(MeasurementUnit.None, MeasurementUnit.KiloGram)]
        [InlineData(MeasurementUnit.KiloGram, MeasurementUnit.HactoGram)]
        [InlineData(MeasurementUnit.KiloGram, MeasurementUnit.Gram)]
        [InlineData(MeasurementUnit.None, MeasurementUnit.Meter)]
        [InlineData(MeasurementUnit.Meter, MeasurementUnit.KiloMeter)]
        [InlineData(MeasurementUnit.Meter, MeasurementUnit.DeciMeter)]
        [InlineData(MeasurementUnit.Meter, MeasurementUnit.CentiMeter)]
        [InlineData(MeasurementUnit.Meter, MeasurementUnit.MiliMeter)]
        [InlineData(MeasurementUnit.None, MeasurementUnit.Piece)]
        [InlineData(MeasurementUnit.None, MeasurementUnit.Boxes)]
        public void AttributeBaseUnit(MeasurementUnit expected, MeasurementUnit unit)
        {
            Assert.Equal(expected, unit.GetBaseUnit());
        }
    }
}
