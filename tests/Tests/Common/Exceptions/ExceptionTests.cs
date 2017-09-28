using Bit0.Utils.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Xunit;

namespace Bit0.Utils.Tests.Common.Exceptions
{
    public class ExceptionTests
    {
        [Fact]
        public void ArgumentMissingException()
        {
            String arg;

            var ex = Assert.ThrowsAsync<ArgumentMissingException>(() => throw new ArgumentMissingException(nameof(arg), new Exception("Test1"))).Result;

            Assert.Equal(500, ex.StatusCode);
            Assert.Equal("Test1", ex.InnerException.Message);
        }

        [Fact]
        public void ExceptionResponce()
        {
            String arg;

            var ex = Assert.ThrowsAsync<ArgumentMissingException>(() => throw new ArgumentMissingException(nameof(arg), new Exception("Test1"))).Result;

            Assert.Equal(500, ex.ResponseObject.StatusCode);
            Assert.Equal(500, ex.ResponseObject.InnerStatus);
            Assert.Equal("Missing argument: arg", ex.ResponseObject.Message);
            Assert.Equal("Test1", ex.ResponseObject.InnerException.Message);

            var ex1 = Assert.ThrowsAsync<InvalidCredentialsException>(() => throw new InvalidCredentialsException(new { val = "Test1" })).Result;
            
            Assert.Equal(403, ex1.ResponseObject.StatusCode);
            Assert.Equal(403, ex1.ResponseObject.InnerStatus);
            Assert.NotNull(ex1.ResponseObject.Data);
            Assert.Equal("Test1", ((dynamic)ex1.ResponseObject.Data).val);
            Assert.Null(ex1.ResponseObject.InnerException);
        }

        [Fact]
        public async void InvalidCredentialsException()
        {
            var ex = await Assert.ThrowsAsync<InvalidCredentialsException>(() => throw new InvalidCredentialsException(new { val = "Test1" }));
            
            Assert.Equal(403, ex.StatusCode);
            Assert.NotNull(ex.Data);
            Assert.Equal("Test1", ((dynamic)ex.ResponseObject.Data).val);
        }

        [Fact]
        public void InvalidObjectTypeException()
        {
            var expected = typeof(String);
            var got = typeof(Int32);
            var ex = Assert.ThrowsAsync<InvalidObjectTypeException>(() => throw new InvalidObjectTypeException(expected, got)).Result;
            
            Assert.Equal(500, ex.StatusCode);
            Assert.Equal($"Error: Expected type '{expected.FullName}' got '{got.FullName}'.", ex.Message);
        }

        [Fact]
        public void KeyMissingException()
        {
            var keyType = typeof(String);
            var key = "arg";
            var ex = Assert.ThrowsAsync<KeyMissingException>(() => throw new KeyMissingException(keyType, key)).Result;

            dynamic data = JObject.Parse(JsonConvert.SerializeObject(ex.ResponseObject.Data));

            Assert.Equal(404, ex.StatusCode);
            Assert.Equal($"{keyType.Name} not found: {key}", data.message.Value as String);
            Assert.Equal(keyType.FullName, data.keyType.Value as String);
            Assert.Equal(key, data.key.Value as String);

            var ex1 = Assert.ThrowsAsync<KeyMissingException>(() => throw new KeyMissingException(key)).Result;
            
            Assert.Equal(404, ex.StatusCode);
            Assert.Equal($"Error: Key not found: {key}", ex1.Message);
        }
    }
}
