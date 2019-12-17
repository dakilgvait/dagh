using System.IO;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Connection.Remote
{
    public interface IRemoteClient<S> where S : Stream
    {
        IRemoteConnection<S> Connection { get; }

        RemoteOptions Options { get; }

        Task<RemoteSession> ConnectAsync();

        Task DisconnectAsync();
    }
}