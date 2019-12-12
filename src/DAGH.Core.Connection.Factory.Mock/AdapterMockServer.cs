using DAGH.Core.Abstractions.Connection;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class AdapterMockServer : IAdapterRemoteServer
    {
        public static AdapterMockServer ConnectionServer { get; set; }

        public AdapterMockServer(ILocalOptions options)
        {
            this.Options = options;
        }

        public ILocalOptions Options { get; }

        public RemoteActionAsync ConnectedActionAsync { get; set; }

        public RemoteActionAsync DisconnectedActionAsync { get; set; }

        public Task StartAsync()
        {
            return Task.Run(() =>
            {
                AdapterMockServer.ConnectionServer = this;
            });
        }

        public async Task OnConnected(IAdapterRemoteClient client)
        {
            await this.ConnectedActionAsync?.Invoke(client);
        }

        public async Task OnDisconnected(IAdapterRemoteClient client)
        {
            await this.DisconnectedActionAsync?.Invoke(client);
        }

        public Task StopAsync()
        {
            return Task.Run(() =>
            {
                AdapterMockServer.ConnectionServer = null;
            });
        }
    }
}