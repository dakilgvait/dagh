using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions.Connection
{
    /// <typeparam name="S">Session</typeparam>
    /// <typeparam name="O">Options</typeparam>
    /// <typeparam name="D">Data</typeparam>
    public interface IConnection<S,  D> : IDisposable
        where S : BaseSession      
        where D : DataBuffer
    {
        S Session { get; }

        Task ReadAsync(D buffer, CancellationToken token);

        Task WriteAsync(D buffer, CancellationToken token);
    }
}