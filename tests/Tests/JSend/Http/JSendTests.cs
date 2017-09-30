using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.Data.Reference;
using Bit0.Utils.JSend.Common;
using Bit0.Utils.JSend.Http;
using Bit0.Utils.JSend.Http.Converter;
using Bit0.Utils.JSend.Http.Exception;
using Bit0.Utils.JSend.Responses;
using Bit0.Utils.Tests.Data.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Bit0.Utils.Tests.JSend.Http
{
    public class JSendTests : ControllerTestBase
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
        public async void Test5()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var resp = _client.GetAsync("/test/action5").Result;
            });
        }
    }

    public class TestController : ControllerBase, IJSendController
    {
        [HttpGet]
        public User Action1()
        {
            return new User
            {
                Username = "user1",
                Password = "user1"
            };
        }

        [HttpGet]
        public User Action2()
        {
            throw new InvalidCredentialsException(new { message = "Error" });
        }

        [HttpGet]
        public User Action3()
        {
            throw new NullObjectException("test");
        }

        [HttpGet]
        public User Action4()
        {
            throw new ArgumentException("missing test");
        }

        [HttpGet]
        public async Task<User> Action5()
        {
            await Response.WriteAsync("Test");

            throw new Exception("response started");
        }
    }

    public class ControllerTestBase
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseEnvironment("Testing");
            var server = new TestServer(builder);
            var client = server.CreateClient();

            // client always expects json results
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }

    internal class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvcCore(opts =>
            {
                opts.Filters.Add(new JSendResultFilter());
            })
            .AddJsonFormatters()
            .AddJsonOptions(opts =>
            {
                opts.SerializerSettings.ContractResolver = new JSendIgnoreContractResolver();
                opts.SerializerSettings.Converters.Add(new DataReferenceJsonConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            app.UseJSendExceptionInterceptor();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureTesting(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            Configure(app, env, loggerFactory);
        }
    }
}
