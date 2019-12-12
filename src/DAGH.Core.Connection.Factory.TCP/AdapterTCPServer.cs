using DAGH.Core.Abstractions.Connection;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.TCP
{
    public class AdapterTCPServer : IAdapterRemoteServer
    {
        public AdapterTCPServer(ILocalOptions options)
        {
            this.Options = options;
            this.TcpListener = new TcpListener(options.LocalIPEndPoint);
        }

        protected TcpListener TcpListener { get; set; }
        public ILocalOptions Options { get; }

        public RemoteActionAsync ConnectedActionAsync { get; set; }

        public RemoteActionAsync DisconnectedActionAsync { get; set; }

        private async void AcceptClientAsync(IAsyncResult result)
        {
            using (TcpClient tcpClient = this.TcpListener.EndAcceptTcpClient(result))
            {
                this.TcpListener.BeginAcceptTcpClient(this.AcceptClientAsync, this.TcpListener);
                using (IAdapterRemoteClient client = new AdapterTCPClient(tcpClient))
                {
                    await this.OnConnected(client);
                    await this.OnDisconnected(client);
                }
            }
        }

        private async Task OnConnected(IAdapterRemoteClient client)
        {
            await this.ConnectedActionAsync?.Invoke(client);
        }

        private async Task OnDisconnected(IAdapterRemoteClient client)
        {
            await this.DisconnectedActionAsync?.Invoke(client);
        }

        public Task StartAsync()
        {
            return Task.Run(() =>
            {
                this.TcpListener.Start();
                this.TcpListener.BeginAcceptTcpClient(this.AcceptClientAsync, this.TcpListener);
            });
        }

        public Task StopAsync()
        {
            return Task.Run(() =>
            {
                if (this.TcpListener.Server.IsBound)
                {
                    this.TcpListener.Stop();
                }
            });
        }
    }
}