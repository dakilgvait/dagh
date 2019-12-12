using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Threading.Tasks;

namespace DAGH.Core.Abstractions
{
    public interface IConnection<S, O> where S : ISession
    {
        Task<S> ConnectAsync(O options);

        Task DisconnectAsync();
    }
}