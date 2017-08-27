using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Common
{
    /// <summary>
    /// List of Measurement units
    /// </summary>
    public enum MeasurementUnit
    {
        /// <summary>
        /// No measurment unit
        /// </summary>
        [MeasurementUnit("None")]
        None = 0,

        /// <summary>
        /// Liter (l)
        /// </summary>
        [MeasurementUnit("l")]
        Liter,

        /// <summary>
        /// Decileter (dl)
        /// </summary>
        [MeasurementUnit("dl", 0.1, Liter)]
        DeciLiter,

        /// <summary>
        /// Centiliter (cl)
        /// </summary>
        [MeasurementUnit("cl", 0.01, Liter)]
        CentiLiter,

        /// <summary>
        /// Mililiter (ml)
        /// </summary>
        [MeasurementUnit("ml", 0.001, Liter)]
        MiliLiter,

        /// <summary>
        /// Kilogram (kg)
        /// </summary>
        [MeasurementUnit("kg")]
        KiloGram,

        /// <summary>
        /// Hactogram (hg)
        /// </summary>
        [MeasurementUnit("hg", 0.1, KiloGram)]
        HactoGram,

        /// <summary>
        /// Gram (g)
        /// </summary>
        [MeasurementUnit("g", 0.001, KiloGram)]
        Gram,

        /// <summary>
        /// Meter (m)
        /// </summary>
        [MeasurementUnit("m")]
        Meter,

        /// <summary>
        /// Kilimeter (km)
        /// </summary>
        [MeasurementUnit("km", 1000, Meter)]
        KiloMeter,

        /// <summary>
        /// Decimeter (dm)
        /// </summary>
        [MeasurementUnit("dm", 0.1, Meter)]
        DeciMeter,

        /// <summary>
        /// Centimeter (cm)
        /// </summary>
        [MeasurementUnit("cm", 0.01, Meter)]
        CentiMeter,

        /// <summary>
        /// Milimeter (mm)
        /// </summary>
        [MeasurementUnit("mm", 0.001, Meter)]
        MiliMeter,

        /// <summary>
        /// Pices (pcs)
        /// </summary>
        [MeasurementUnit("pcs")]
        Piece,

        /// <summary>
        /// Boxes (boxes)
        /// </summary>
        [MeasurementUnit("boxes")]
        Boxes
    }
}