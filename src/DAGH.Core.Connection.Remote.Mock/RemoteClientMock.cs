using DAGH.Core.Abstractions;
using DAGH.Core.Abstractions.Connection.Remote;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class RemoteConnection : IRemoteConnection<MemoryStream>
    {
        public RemoteConnection(MemoryStream stream, RemoteSession session)
        {
            this.Stream = stream;
            this.Session = session;
        }

        public MemoryStream Stream { get; }

        public RemoteSession Session { get; }

        public void Dispose()
        {
            this.Stream.Dispose();
        }

        public async Task ReadAsync(DataBuffer buffer, CancellationToken token)
        {
            buffer.Length = await this.Stream.ReadAsync(buffer.Data, buffer.Length, buffer.LengthOfEmpty, token);
        }

        public async Task WriteAsync(DataBuffer buffer, CancellationToken token)
        {
            await this.Stream.WriteAsync(buffer.Data, 0, buffer.Length, token);
        }
    }

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
                var session = await RemoteServerMock.ServerMock.OnConnected(this);
                this.Connection = new RemoteConnection(new MemoryStream(), session);
                return session;
            });
        }

        public Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }
    }
}