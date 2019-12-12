using System.Net;

namespace DAGH.Core.Abstractions.Connection
{
    public interface IRemoteOptions
    {
        IPEndPoint RemoteIPEndPoint { get; }
    }
}