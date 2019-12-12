using System.Threading.Tasks;

namespace DAGH.Core.Abstractions
{
    public interface IRunnable
    {
        Task StartAsync();

        Task StopAsync();
    }
}