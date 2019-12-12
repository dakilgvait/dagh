using DAGH.Core.Abstractions.Models;
using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Connection
{
    public interface IAdapterRemoteClient : IConnection<IRemoteSession, IRemoteOptions>, IDisposable
    {
        public Task ReadFromClientAsync(IDataBuffer buffer, CancellationToken token);

        public Task ReadFromServerAsync(IDataBuffer buffer, CancellationToken token);

        public Task WriteToClientAsync(IDataBuffer buffer, CancellationToken token);

        public Task WriteToServerAsync(IDataBuffer buffer, CancellationToken token);
    }
}