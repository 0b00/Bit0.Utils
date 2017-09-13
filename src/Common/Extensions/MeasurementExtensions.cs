using System;
using Bit0.Utils.Common.Attributes;

namespace Bit0.Utils.Common.Extensions
{
    /// <summary>
    /// Measurement extensions
    /// </summary>
    public static class MeasurementExtensions
    {
        /// <summary>
        /// Get <see cref="MeasurementUnitAttribute.ShortName"/>
        /// </summary>
        /// <param name="u"><see cref="MeasurementUnit"/> field value</param>
        /// <returns></returns>
        public static String GetShortname(this MeasurementUnit u)
        {
            return u.GetFieldAttribute<MeasurementUnitAttribute>().ShortName;
        }

        /// <summary>
        /// Get <see cref="MeasurementUnitAttribute.BaseUnit"/>
        /// </summary>
        /// <param name="u"><see cref="MeasurementUnit"/> field value</param>
        /// <returns></returns>
        public static MeasurementUnit GetBaseUnit(this MeasurementUnit u)
        {
            return u.GetFieldAttribute<MeasurementUnitAttribute>().BaseUnit;
        }

        /// <summary>
        /// Get <see cref="MeasurementUnitAttribute.ConversionFactor"/>
        /// </summary>
        /// <param name="u"><see cref="MeasurementUnit"/> field value</param>
        /// <returns></returns>
        public static Double GetConversionFactor(this MeasurementUnit u)
        {
            return u.GetFieldAttribute<MeasurementUnitAttribute>().ConversionFactor;
        }

        /// <summary>
        /// Get value of measurment normalized to <see cref="MeasurementUnitAttribute.BaseUnit"/>
        /// </summary>
        /// <param name="m"><see cref="Measurement"/> object</param>
        /// <returns></returns>
        public static Measurement GetNormalizedValue(this Measurement m)
        {
            if (m.Unit.GetBaseUnit() == MeasurementUnit.None)
            {
                return m;
            }

            var tm = new Measurement
            {
                Unit = m.Unit.GetBaseUnit(),
                Value = m.Value * m.Unit.GetConversionFactor()
            };

            return tm;
        }
    }
}
