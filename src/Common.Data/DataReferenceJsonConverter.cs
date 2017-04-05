using System;
using Newtonsoft.Json;

namespace Bit0.Utils.Common.Data
{
    public class DataReferenceJsonConverter : JsonConverter
    {
        #region Public Methods

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataReference);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = (string)reader.Value;

            return DataReference.Parse(str);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue($"\"{((DataReference)value).Id}\"");
        }

        #endregion Public Methods
    }
}