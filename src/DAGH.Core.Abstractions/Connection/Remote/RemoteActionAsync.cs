using System.IO;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Connection.Remote
{
    public delegate Task RemoteActionAsync<S>(IRemoteClient<S> client)
        where S : Stream;
}