using Bit0.Utils.Common.Attributes;
using Bit0.Utils.Common.Convertors;
using Bit0.Utils.Common.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace Bit0.Utils.Tests.Common.Convertors
{
    public class StringValueEnumConvertorTests
    {
        [Fact]
        public void WriteJson()
        {
            var stringWriter = new StringWriter();
            var writer = new JsonTextWriter(stringWriter);

            var conv = new StringValueEnumConvertor();
            conv.WriteJson(writer, StringTest.Item1, JsonSerializer.Create());

            var str = stringWriter.GetStringBuilder().ToString();

            Assert.Equal("\"Item1\"", str);
        }

        [Fact]
        public void WriteJsonNull()
        {
            var stringWriter = new StringWriter();
            var writer = new JsonTextWriter(stringWriter);

            var conv = new StringValueEnumConvertor();

            Assert.Throws<NullObjectException>(() =>
            {
                conv.WriteJson(writer, null, JsonSerializer.Create());
            });

            Assert.Throws<InvalidCastException>(() =>
            {
                conv.WriteJson(writer, "", JsonSerializer.Create());
            });
        }

        internal enum StringTest
        {
            [String("Item1")]
            Item1,

            [String("Item2")]
            Item2
        }
    }
}
