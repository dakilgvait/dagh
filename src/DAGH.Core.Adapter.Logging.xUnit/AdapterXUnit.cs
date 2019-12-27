using DAGH.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace DAGH.Core.Adapter.Logging.xUnit
{
    public class AdapterXUnit : IAdapter
    {
        private ITestOutputHelper OutputHelper { get; }

        public AdapterXUnit(ITestOutputHelper outputHelper)
        {
            this.OutputHelper = outputHelper;
        }

        public void Configure(IServiceCollection services)
        {
            services.AddLogging(b => b.AddXUnit(this.OutputHelper));
        }
    }
}