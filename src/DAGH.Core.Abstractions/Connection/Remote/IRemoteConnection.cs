using System.IO;

namespace DAGH.Core.Abstractions.Connection.Remote
{
    public interface IRemoteConnection<S> : IConnection<RemoteSession, DataBuffer>
        where S : Stream
    {
        S Stream { get; }
    }
}