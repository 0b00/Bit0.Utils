using System;
using System.Collections.Generic;
using System.Text;
using Bit0.Utils.Data.Reference;
using Newtonsoft.Json;
using Xunit;

namespace Bit0.Utils.Tests.Data.Providers
{
    public class DataReferenceJsonConverterTests
    {
        private readonly DataReferenceJsonConverter _dataReferenceJsonConverter;

        public DataReferenceJsonConverterTests()
        {
            _dataReferenceJsonConverter = new DataReferenceJsonConverter();
        }

        [Fact]
        public void CanCovert()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(_dataReferenceJsonConverter);

            var id = DataReference.NewIdentity();

            var json = JsonConvert.SerializeObject(id, settings);
            var deJson = JsonConvert.DeserializeObject<DataReference>(json, settings);

            Assert.Equal(deJson, id);
        }
    }
}
