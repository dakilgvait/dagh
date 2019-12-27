using DAGH.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DAGH.Core.Adapter.log4net
{
    public class AdapterLog4net : IAdapter
    {
        public void Configure(IServiceCollection services)
        {
            services.AddLogging(b => b.AddLog4Net());
        }
    }
}