using DAGH.Core.Abstractions.Connection;
using System.Net;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class RemoteOptionsMock : IRemoteOptions
    {
        public IPEndPoint RemoteIPEndPoint { get; set; }
    }
}