using System.Net;

namespace DAGH.Core.Abstractions.Connection.Remote
{
    public class RemoteOptions : ConnectionOptions
    {
        IPEndPoint RemoteIPEndPoint { get; }
    }
}