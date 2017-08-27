using Bit0.Utils.Common;
using Bit0.Utils.Common.Extensions;
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

        [Fact]
        public void ShortNameValueTest()
        {
            Assert.Equal("l", MeasurementUnit.Liter.GetShortname());
            Assert.Equal("dl", MeasurementUnit.DeciLiter.GetShortname());
            Assert.Equal("cl", MeasurementUnit.CentiLiter.GetShortname());
            Assert.Equal("ml", MeasurementUnit.MiliLiter.GetShortname());
            Assert.Equal("kg", MeasurementUnit.KiloGram.GetShortname());
            Assert.Equal("hg", MeasurementUnit.HactoGram.GetShortname());
            Assert.Equal("g", MeasurementUnit.Gram.GetShortname());
            Assert.Equal("m", MeasurementUnit.Meter.GetShortname());
            Assert.Equal("km", MeasurementUnit.KiloMeter.GetShortname());
            Assert.Equal("dm", MeasurementUnit.DeciMeter.GetShortname());
            Assert.Equal("cm", MeasurementUnit.CentiMeter.GetShortname());
            Assert.Equal("mm", MeasurementUnit.MiliMeter.GetShortname());
            Assert.Equal("pcs", MeasurementUnit.Piece.GetShortname());
            Assert.Equal("boxes", MeasurementUnit.Boxes.GetShortname());
        }

        [Fact]
        public void AttributeConversionFactor()
        {
            Assert.Equal(1d, MeasurementUnit.Liter.GetConversionFactor());
            Assert.Equal(1d / 10, MeasurementUnit.DeciLiter.GetConversionFactor());
            Assert.Equal(1d / 100, MeasurementUnit.CentiLiter.GetConversionFactor());
            Assert.Equal(1d / 1000, MeasurementUnit.MiliLiter.GetConversionFactor());
            Assert.Equal(1d, MeasurementUnit.KiloGram.GetConversionFactor());
            Assert.Equal(1d / 10, MeasurementUnit.HactoGram.GetConversionFactor());
            Assert.Equal(1d / 1000, MeasurementUnit.Gram.GetConversionFactor());
            Assert.Equal(1d, MeasurementUnit.Meter.GetConversionFactor());
            Assert.Equal(1000d, MeasurementUnit.KiloMeter.GetConversionFactor());
            Assert.Equal(1d / 10, MeasurementUnit.DeciMeter.GetConversionFactor());
            Assert.Equal(1d / 100, MeasurementUnit.CentiMeter.GetConversionFactor());
            Assert.Equal(1d / 1000, MeasurementUnit.MiliMeter.GetConversionFactor());
            Assert.Equal(1d, MeasurementUnit.Piece.GetConversionFactor());
            Assert.Equal(1d, MeasurementUnit.Boxes.GetConversionFactor());
        }

        [Fact]
        public void AttributeBaseUnit()
        {
            Assert.Equal(MeasurementUnit.None, MeasurementUnit.Liter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Liter, MeasurementUnit.DeciLiter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Liter, MeasurementUnit.CentiLiter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Liter, MeasurementUnit.MiliLiter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.None, MeasurementUnit.KiloGram.GetBaseUnit());
            Assert.Equal(MeasurementUnit.KiloGram, MeasurementUnit.HactoGram.GetBaseUnit());
            Assert.Equal(MeasurementUnit.KiloGram, MeasurementUnit.Gram.GetBaseUnit());
            Assert.Equal(MeasurementUnit.None, MeasurementUnit.Meter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Meter, MeasurementUnit.KiloMeter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Meter, MeasurementUnit.DeciMeter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Meter, MeasurementUnit.CentiMeter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.Meter, MeasurementUnit.MiliMeter.GetBaseUnit());
            Assert.Equal(MeasurementUnit.None, MeasurementUnit.Piece.GetBaseUnit());
            Assert.Equal(MeasurementUnit.None, MeasurementUnit.Boxes.GetBaseUnit());
        }
    }
}
