using Bit0.Utils.Data.Reference;
using Bit0.Utils.JSend.Http;
using Bit0.Utils.JSend.Http.Converter;
using Bit0.Utils.JSend.Http.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bit0.Utils.Tests.TestSetup
{
    public class Startup
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