using System;
using Bit0.Utils.Common.Attributes;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bit0.Utils.Common.Convertors
{
    /// <summary>
    /// Converts an System.Enum to and from its name string value.
    /// </summary>
    public class StringValueEnumConvertor : StringEnumConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                throw new NullObjectException(nameof(value));
            }

            if (!(value is Enum))
            {
                throw new InvalidCastException($"Expected type '{typeof(Enum).FullName}' got '{value.GetType().FullName}'.");
            }

            var v = (Enum)value;
            writer.WriteValue(v.GetFieldAttribute<StringAttribute>().Value);
        }
    }
}
