using System.Text;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Adapters
{
    public interface ILoggerOptions
    {
        Encoding Encoding { get; }
    }

    public interface IAdapterLogger
    {
        ILoggerOptions Options { get; }

        Task DebugAsync(object msg);

        Task ErrorAsync(object msg);

        Task InfoAsync(object msg);

        Task WarnAsync(object msg);
    }
}