using DAGH.Core.Adapter.log4net;
using DAGH.Core.Adapter.Logging.xUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Log4net
    {
        private IServiceProvider ServiceProvider { get; }

        public Log4net(ITestOutputHelper outputHelper)
        {
            var services = new ServiceCollection();
            AdapterXUnit adapterXUnit = new AdapterXUnit(outputHelper);
            AdapterLog4net adapterLog4Net = new AdapterLog4net();
            adapterXUnit.Configure(services);
            adapterLog4Net.Configure(services);
            this.ServiceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void LogError()
        {
            var l = this.ServiceProvider.GetService<ILogger<Log4net>>();
            l.LogError("test");
            Assert.True(true);
        }
    }
}