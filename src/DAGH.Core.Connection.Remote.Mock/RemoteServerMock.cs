using DAGH.Core.Abstractions.Connection;
using DAGH.Core.Abstractions.Connection.Remote;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class RemoteServerMock : IRemoteServer<MemoryStream>
    {
        private static bool IsStarted { get; set; }
        public static RemoteServerMock ServerMock { get; private set; }

        public RemoteServerMock(ConnectionOptions options)
        {
            this.Options = options;
        }

        public ConnectionOptions Options { get; }

        public event RemoteActionAsync<MemoryStream> ClientHandler;

        public Task StartAsync()
        {
            return Task.Run(() =>
            {
                if (RemoteServerMock.IsStarted)
                {
                    throw new InvalidOperationException("Server allready started");
                }
                else
                {
                    RemoteServerMock.ServerMock = this;
                }
            });
        }

        public Task StopAsync()
        {
            return Task.Run(() =>
            {
                if (RemoteServerMock.IsStarted)
                {
                    RemoteServerMock.ServerMock = this;
                }
                else
                {
                    throw new InvalidOperationException("Server allready stopped");
                }
            });
        }

        public async Task OnConnected(IRemoteClient<MemoryStream> client)
        {
            if (this.ClientHandler != null)
            {
                await this.ClientHandler(client);
            }
        }

        public RemoteSession CreateSession()
        {
            return new RemoteSession();
        }

        public RemoteSession DisposeSession(Guid id)
        {
            return new RemoteSession();
        }
    }
}