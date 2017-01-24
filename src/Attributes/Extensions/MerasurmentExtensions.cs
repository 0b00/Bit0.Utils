using Bit0.Utils;
using Bit0.Utils.Extensions;
using SmartOrder.Attributes;

namespace SmartOrder.Extensions
{
    /// <summary>
    /// Measurment extensions
    /// </summary>
    public static class MerasurmentExtensions
    {
        /// <summary>
        /// Get <see cref="MeasurementUnitAttribute.ShortName"/>
        /// </summary>
        /// <param name="u"><see cref="MeasurementUnit"/> field value</param>
        /// <returns></returns>
        public static string GetShortname(this MeasurementUnit u)
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
        public static double GetConversionFactor(this MeasurementUnit u)
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
