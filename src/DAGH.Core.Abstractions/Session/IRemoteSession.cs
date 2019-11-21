using System.Net;

namespace DAGH.Core.Abstractions.Models.Session
{
    public interface IRemoteSession : ISession
    {
        IPEndPoint RemoteIPEndPoint { get; }
    }
}