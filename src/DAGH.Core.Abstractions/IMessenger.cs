using System.Threading.Tasks;

namespace DAGH.Core.Abstractions
{
    public delegate Task MessageActionAsync(string info, object message);

    public interface IMessenger
    {
        MessageActionAsync OnMessageActionAsync { get; set; }

        Task LogAsync(object msg);
    }
}