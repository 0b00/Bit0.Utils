using Bit0.Utils.Http.Filters;
using System;
using Bit0.Utils.Data.Http.Attributes;
using Xunit;

namespace Bit0.Utils.Tests.Http.Filters
{
    public class AttributeTests
    {
        [Theory]
        [InlineData("", false, false, false)]
        [InlineData("", false, true, false)]
        [InlineData("", false, false, true)]
        [InlineData("", false, true, true)]
        [InlineData("nul", false, false, false)]
        [InlineData("nul", false, false, true)]
        [InlineData("nul", false, true, false)]
        [InlineData(null, true, false, false)]
        [InlineData(null, false, false, true)]
        [InlineData(null, true, true, false)]
        [InlineData(null, false, true, true)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8", true, false, false)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8", true, false, true)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8", true, true, false)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8", true, true, true)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8,{6AFEEF03-CD32-468B-8D4A-BC46CB8DC29E}", false, false, false)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8,{6AFEEF03-CD32-468B-8D4A-BC46CB8DC29E}", false, false, true)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8,{6AFEEF03-CD32-468B-8D4A-BC46CB8DC29E}", true, true, false)]
        [InlineData("e8a3314e-8c0d-4a81-8802-ab21f9c0b2e8,{6AFEEF03-CD32-468B-8D4A-BC46CB8DC29E}", true, true, true)]
        public void GuidTest(String input, Boolean expected, Boolean hasList, Boolean required)
        {
            var attr = new GuidAttribute(hasList: hasList, required: required);
            var actual = attr.IsValid(hasList ? (Object)input?.Split(',') : input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", true)]
        [InlineData(true, true)]
        [InlineData(1, true)]
        [InlineData("t", true)]
        public void NotNUllTest(Object value, Boolean expected)
        {
            var attr = new NotNullAttribute();
            var actual = attr.IsValid(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(true, false)]
        [InlineData(1, false)]
        [InlineData("t", false)]
        [InlineData(new Object[] {}, false)]
        [InlineData(new Object[] {""}, true)]
        public void NotEmptyTest(Object value, Boolean expected)
        {
            var attr = new NotEmptyAttribute();
            var actual = attr.IsValid(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, false, true)]
        [InlineData(null, true, false)]
        public void NullGuid(Object value, Boolean required,  Boolean expected)
        {
            var attr = new GuidAttribute(false, required: required);
            var actual = attr.IsValid(value);

            Assert.Equal(expected, actual);
        }
    }
}
