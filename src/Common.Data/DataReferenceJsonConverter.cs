using System;
using Newtonsoft.Json;

namespace Bit0.Utils.Common.Data
{
    /// <summary>
    /// <see cref="JsonConverter"/> for <see cref="DataReference"/>.
    /// Serialize only the Id as string.
    /// </summary>
    public class DataReferenceJsonConverter : JsonConverter
    {
        #region Public Methods
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataReference);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = (string)reader.Value;

            return DataReference.Parse(str);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue($"\"{((DataReference)value).Id}\"");
        }

        #endregion Public Methods
    }
}