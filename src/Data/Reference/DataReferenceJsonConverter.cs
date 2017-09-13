using System;
using Newtonsoft.Json;

namespace Bit0.Utils.Data.Reference
{
    /// <summary>
    /// <see cref="JsonConverter"/> for <see cref="DataReference"/>.
    /// Serialize only the Id as string.
    /// </summary>
    public class DataReferenceJsonConverter : JsonConverter
    {
        #region Public Methods
        /// <inheritdoc />
        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(DataReference);
        }

        /// <inheritdoc />
        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            var str = (String)reader.Value;

            return DataReference.Parse(str);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            writer.WriteRawValue($"\"{((DataReference)value).Id}\"");
        }

        #endregion Public Methods
    }
}