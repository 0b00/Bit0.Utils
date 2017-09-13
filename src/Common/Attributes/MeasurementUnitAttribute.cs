using System;

// ReSharper disable MemberCanBePrivate.Global

namespace Bit0.Utils.Common.Attributes
{
    /// <summary>
    /// Add meta data to <see cref="MeasurementUnit"/> enum fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MeasurementUnitAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of <see cref="MeasurementUnitAttribute"/> class
        /// </summary>
        /// <param name="shortName">Short name for <see cref="MeasurementUnit"/></param>
        /// <param name="factor">Conversion factor to <see cref="BaseUnit"/>of  <see cref="MeasurementUnit"/></param>
        /// <param name="baseunit">Base unit of  <see cref="MeasurementUnit"/></param>
        public MeasurementUnitAttribute(String shortName, Double factor = 1, MeasurementUnit baseunit = MeasurementUnit.None)
        {
            ShortName = shortName;
            ConversionFactor = factor;
            BaseUnit = baseunit;
        }

        /// <summary>
        /// Short name for <see cref="MeasurementUnit"/>
        /// </summary>
        public String ShortName { get; set; }

        /// <summary>
        /// Conversion factor to <see cref="BaseUnit"/> of  <see cref="MeasurementUnit"/>
        /// </summary>
        public Double ConversionFactor { get; set; }

        /// <summary>
        /// Base unit of  <see cref="MeasurementUnit"/>
        /// </summary>
        public MeasurementUnit BaseUnit { get; set; }
    }
}
