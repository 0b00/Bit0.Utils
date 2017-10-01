using System;
using System.Net;
using System.Net.Http;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Common;
using Bit0.Utils.JSend.Responses;
using Bit0.Utils.Tests.JSend.Http.TestSetup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            var resp = _client.GetAsync("/test/action2").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JObject.Parse(str);

            Assert.Equal(403, error["statusCode"]);
            Assert.Equal("Error", error["data"]["message"]);

        }

        [Fact]
        public async void Test4()
        {

            var resp = _client.GetAsync("/test/action4").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JObject.Parse(str);

            Assert.Equal(500, error["code"]["code"]);
            Assert.Equal("missing test", error["message"]);

        }
    }
}
