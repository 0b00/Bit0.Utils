using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Bit0.Utils.Tests.TestSetup
{
    public class ControllerTestBase<TStartup> where TStartup : class
    {
        private TestServer _server;

        protected TestServer GetServer()
        {
            if (_server != null) return _server;

            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<TStartup>()
                .UseEnvironment("Testing");
            _server = new TestServer(builder);

            return _server;
        }

        protected HttpClient GetClient()
        {
            var server = GetServer();
            var client = server.CreateClient();

            // client always expects json results
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}