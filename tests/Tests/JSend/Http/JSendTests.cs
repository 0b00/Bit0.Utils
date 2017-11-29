using System;
using System.Net;
using System.Net.Http;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.JSend.Common;
using Bit0.Utils.JSend.Responses;
using Bit0.Utils.Tests.Data.Providers;
using Bit0.Utils.Tests.JSend.Http.TestSetup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Bit0.Utils.Tests.JSend.Http
{
    public class JSendTests : ControllerTestBase<Startup>
    {
        private readonly HttpClient _client;

        public JSendTests()
        {
            _client = GetClient();
        }

        [Fact]
        public async void Test1()
        {
            var resp = await _client.GetAsync("/test/action1");
            resp.EnsureSuccessStatusCode();
            var str = await resp.Content.ReadAsStringAsync();

            var success = JsonConvert.DeserializeObject<JSendResponse<User>>(str);

            Assert.Equal(200, success.StatusCode.Code);
            Assert.Equal("user1", success.Data.Username);
            Assert.True(String.IsNullOrWhiteSpace(success.Data.Password));
        }

        [Fact]
        public async void Test1a()
        {
            var resp = await _client.GetAsync("/test2/action1");
            resp.EnsureSuccessStatusCode();
            var str = await resp.Content.ReadAsStringAsync();

            var success = JObject.Parse(str);
            
            Assert.Equal("user1", success["username"]);
            Assert.Null(success["password"]);
        }

        [Fact]
        public async void Test2()
        {

            var resp = _client.GetAsync("/test/action2").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var fail = JsonConvert.DeserializeObject<JSendResponse>(str);

            Assert.Equal(HttpStatusCode.Forbidden, resp.StatusCode);
            Assert.Equal(403, fail.StatusCode.Code);
            Assert.Equal(JSendStatus.Success.GetValue(), fail.StringStatus);
            Assert.Equal("Error", ((JObject)fail.Data)["message"].Value<String>());
        }

        [Fact]
        public async void Test3()
        {

            var resp = _client.GetAsync("/test/action3").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JsonConvert.DeserializeObject<JSendResponse>(str);

            Assert.Equal(HttpStatusCode.InternalServerError, resp.StatusCode);
            Assert.Equal(500, error.StatusCode.Code);
            Assert.Equal(JSendStatus.Success.GetValue(), error.StringStatus);
            Assert.Equal("Null object: test", error.Message);
        }

        [Fact]
        public async void Test4()
        {

            var resp = _client.GetAsync("/test/action4").Result;
            var str = await resp.Content.ReadAsStringAsync();

            var error = JsonConvert.DeserializeObject<JSendResponse>(str);

            Assert.Equal(HttpStatusCode.InternalServerError, resp.StatusCode);
            Assert.Equal(500, error.StatusCode.Code);
            Assert.Equal(JSendStatus.Success.GetValue(), error.StringStatus);
            Assert.Equal("missing test", error.Message);
        }

        [Fact]
        public void Test5()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var resp = _client.GetAsync("/test/action5").Result;
            });
        }
    }
}
