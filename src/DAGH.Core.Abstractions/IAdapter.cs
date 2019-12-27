using Microsoft.Extensions.DependencyInjection;

namespace DAGH.Core.Abstractions
{
    public interface IAdapter
    {
        void Configure(IServiceCollection parameter);
    }
}