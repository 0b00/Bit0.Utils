namespace Bit0.Utils.Common
{
    /// <summary>
    /// Measurement
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// Measurement type
        /// </summary>
        public MeasurementUnit Unit { get; set; } = MeasurementUnit.None;
        /// <summary>
        /// Measurement amount
        /// </summary>
        public double Value { get; set; } = 0;
    }
}