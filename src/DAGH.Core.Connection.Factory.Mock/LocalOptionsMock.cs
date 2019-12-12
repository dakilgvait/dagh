using DAGH.Core.Abstractions.Connection;
using System.Net;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class LocalOptionsMock : ILocalOptions
    {
        public IPEndPoint LocalIPEndPoint { get; set; }
    }
}