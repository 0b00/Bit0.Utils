using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Bit0.Utils.Tests.JSend.Http.TestSetup
{
    public class ControllerTestBase<TStartup> where TStartup : class 
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<TStartup>()
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
}