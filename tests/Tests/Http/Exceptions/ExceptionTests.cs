using System;
using Bit0.Utils.Http.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Bit0.Utils.Tests.Http.Exceptions
{
    public class ExceptionTests
    {
        [Fact]
        public void ModelValidationException()
        {
            var ex = Assert.ThrowsAsync<ModelValidationException>(() => throw new ModelValidationException(new { val = "Test1" })).Result;

            Assert.Equal(400, ex.StatusCode);
            Assert.NotNull(ex.Data);
            Assert.Equal("Test1", ((dynamic)ex.ResponseObject.Data).val);
        }

        [Fact]
        public void UrlNotFoundException()
        {
            var ex = Assert.ThrowsAsync<UrlNotFoundException>(() => throw new UrlNotFoundException("test1", new Exception("Test"))).Result;

            Assert.Equal(404, ex.StatusCode);
            Assert.NotNull(ex.Data);
            Assert.IsType<Exception>(ex.InnerException);
            Assert.Equal("Test", ex.InnerException.Message);

            var data = JToken.Parse(JsonConvert.SerializeObject(ex.ResponseObject.Data));

            Assert.Equal("test1", data["route"]);
        }
    }
}
