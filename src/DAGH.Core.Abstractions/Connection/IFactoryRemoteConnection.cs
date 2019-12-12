using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Connection
{
    public delegate Task RemoteActionAsync(IAdapterRemoteClient connectionClient);

    public interface IFactoryRemoteConnection
    {
        IAdapterRemoteClient CreateClient();

        IAdapterRemoteServer CreateServer(ILocalOptions options);
    }
}