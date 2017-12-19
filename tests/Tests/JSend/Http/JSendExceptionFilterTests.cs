using Bit0.Utils.Tests.TestSetup;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Xunit;

namespace Bit0.Utils.Tests.JSend.Http
{
    public class JSendExceptionFilterTests : ControllerTestBase<Startup2>
    {

        private readonly HttpClient _client;

        public JSendExceptionFilterTests()
        {
            _client = GetClient();
        }

        [Fact]
        public async void Test2()
        {

            var resp = _client.GetAsync("/test1/action2").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JObject.Parse(str);

            Assert.Equal(403, error["statusCode"]);
            Assert.Equal("Error", error["data"]["message"]);

        }

        [Fact]
        public async void Test4()
        {

            var resp = _client.GetAsync("/test1/action4").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JObject.Parse(str);

            Assert.Equal(500, error["code"]["code"]);
            Assert.Equal("missing test", error["message"]);

        }
    }
}
