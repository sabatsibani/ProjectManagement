using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using System;
using Xunit;
using Xunit.Abstractions;
using GenericSutFactory = Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<ProjectManagement.Api.Startup>;
using SutFactory = ProjectManagement.Api.Test.CustomWebApplicationFactory<ProjectManagement.Api.Startup>;

namespace ProjectManagement.Api.Test
{
    public class DisposableAppTestBase<WebAppEntryPoint> : TestBase,IClassFixture<SutFactory>, IDisposable where WebAppEntryPoint:class
    {
        private bool _disposed = false;
        protected GenericSutFactory SystemUnderTestFactory { get; }

        public void Dispose()
        {
            Dispose(true);
        }
        protected DisposableAppTestBase()
        {

        }
        protected virtual void ConfigureTestServices(IServiceCollection services, ITestOutputHelper testOutput)
        {

        }

        //protected DisposableAppTestBase(SutFactory sutFactory,
        //    ITestOutputHelper testOutput,
        //    LogEventLevel minimumLogLevel=SerilogHelper.DefaultLogLevel): base(testOutput,minimumLogLevel)
        //{
           
        //}

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                _disposed = true;
                if(disposing)
                {
                   // IHostedService hostedService = SystemUnderTestFactory.Server.Services.GetRequiredService<IHostedService>();

                }
            }
        }
    }

    internal class SerilogHelper
    {
        public const LogEventLevel DefaultLogLevel = LogEventLevel.Information;
    }
}
