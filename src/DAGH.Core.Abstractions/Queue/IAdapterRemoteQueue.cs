using DAGH.Core.Abstractions.Models;
using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Adapters
{
    public delegate Task RemoteQueueActionAsync(IRemoteQueueBuffer buffer);

    public interface IAdapterRemoteQueue : IDisposable
    {
        IRemoteSession RemoteSession { get; }
        RemoteQueueActionAsync OnReceviedActionAsync { get; set; }

        Task SendAsync(IRemoteQueueBuffer buffer);
    }

    public interface IRemoteQueueBuffer : IDataBuffer
    {
        string Key { get; }
    }
}