using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Net;

namespace DAGH.Core.Abstractions.Models
{
    public class RemoteSession : IRemoteSession
    {
        public IPEndPoint RemoteIPEndPoint { get; set; }

        public Guid SessionId { get; set; }
    }
}