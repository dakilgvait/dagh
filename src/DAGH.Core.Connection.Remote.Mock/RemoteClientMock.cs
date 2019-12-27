using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Remote.Mock;
using System.IO;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class RemoteClientMock : IRemoteClient<MemoryStream>
    {
        public RemoteClientMock(RemoteOptions options)
        {
            this.Options = options;
        }

        public IRemoteConnection<MemoryStream> Connection { get; private set; }

        public RemoteOptions Options { get; }

        public Task<RemoteSession> ConnectAsync()
        {
            return Task.Run(async () =>
            {
                if (RemoteServerMock.ServerMock != null)
                {
                    var session = RemoteServerMock.ServerMock.CreateSession();
                    this.Connection = new RemoteConnectionMock(new MemoryStream(), session);
                    await RemoteServerMock.ServerMock.OnConnected(this);
                    return session;
                }
                else
                {
                    return null;
                }
            });
        }

        public Task DisconnectAsync()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}