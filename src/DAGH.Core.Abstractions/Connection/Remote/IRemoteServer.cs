using System.IO;

namespace DAGH.Core.Abstractions.Connection.Remote
{
    public interface IRemoteServer<S> : IRunnable 
        where S:Stream
    {
        ConnectionOptions Options { get; }

        event RemoteActionAsync<S> ClientHandler;
    }
}