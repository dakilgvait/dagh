using System.Net;

namespace DAGH.Core.Abstractions.Connection
{
    public interface ILocalOptions
    {
        IPEndPoint LocalIPEndPoint { get; }
    }
}