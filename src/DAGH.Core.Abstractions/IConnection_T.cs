using System.Threading.Tasks;

namespace DAGH.Core.Abstractions
{
    public interface IConnection<T>
    {
        Task<T> ConnectAsync();

        Task DisconnectAsync();
    }
}