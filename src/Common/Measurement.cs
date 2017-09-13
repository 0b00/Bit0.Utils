using System;

namespace Bit0.Utils.Common
{
    /// <summary>
    /// Measurement
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// Measurement
        /// </summary>
        /// <param name="unit">type</param>
        /// <param name="value">amount</param>
        public Measurement(MeasurementUnit unit = MeasurementUnit.None, Double value = 0)
        {
            Unit = unit;
            Value = value;
        }

        /// <summary>
        /// Measurement type
        /// </summary>
        public MeasurementUnit Unit { get; set; }
        /// <summary>
        /// Measurement amount
        /// </summary>
        public Double Value { get; set; }
    }
}