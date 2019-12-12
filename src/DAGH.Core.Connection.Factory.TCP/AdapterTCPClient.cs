using DAGH.Core.Abstractions.Connection;
using DAGH.Core.Abstractions.Models;
using DAGH.Core.Abstractions.Models.Session;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.TCP
{
    public class AdapterTCPClient : IAdapterRemoteClient
    {
        private TcpClient TcpClient { get; }

        public AdapterTCPClient(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
        }

        public AdapterTCPClient()
            : this(new TcpClient()) { }

        public async Task<IRemoteSession> ConnectAsync(IRemoteOptions options)
        {
            await this.TcpClient.ConnectAsync(options.RemoteIPEndPoint.Address, options.RemoteIPEndPoint.Port);
            IRemoteSession session = new RemoteSession()
            {
                RemoteIPEndPoint = options.RemoteIPEndPoint,
                SessionId = Guid.NewGuid()
            };
            return session;
        }

        public Task DisconnectAsync()
        {
            return Task.Run(() =>
            {
                this.TcpClient.Close();
            });
        }

        public void Dispose()
        {
            this.TcpClient.Dispose();
        }

        public Task ReadFromClientAsync(IDataBuffer buffer, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task ReadFromServerAsync(IDataBuffer buffer, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task WriteToClientAsync(IDataBuffer buffer, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task WriteToServerAsync(IDataBuffer buffer, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}