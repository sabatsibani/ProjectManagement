using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ProjectManagement.Api.Test
{
    public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup> where TStartup:class
    {
        const string ConfigFileName = "appsettings.json";
        const string TestConfigFileName = "test-configuration.json";
        private readonly string _integrationTestsBinDirectory;

        public CustomWebApplicationFactory()
        {
            _integrationTestsBinDirectory = Directory.GetCurrentDirectory();
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            IHost host = base.CreateHost(builder);

            return host;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {

            }
            base.Dispose(disposing);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureAppConfiguration((context, conf) =>
            {
                
            });
        }
    }
}
