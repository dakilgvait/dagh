using DAGH.Core.Abstractions.Connection;
using DAGH.Core.Abstractions.Models;
using DAGH.Core.Abstractions.Models.Session;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class AdapterMockClient : IAdapterRemoteClient
    {
        public AdapterMockClient()
        {
            this.ServerStream = new MemoryStream();
            this.ClientStream = new MemoryStream();
            this.ServerStreamH = new EventWaitHandle(false, EventResetMode.AutoReset);
            this.ClientStreamH = new EventWaitHandle(false, EventResetMode.AutoReset);
        }
        protected MemoryStream ServerStream { get; }
        protected MemoryStream ClientStream { get; }
        private EventWaitHandle ServerStreamH { get; }
        private EventWaitHandle ClientStreamH { get; }

        public async Task<IRemoteSession> ConnectAsync(IRemoteOptions options)
        {
            await AdapterMockServer.ConnectionServer.OnConnected(this);
            IRemoteSession session = new RemoteSession()
            {
                RemoteIPEndPoint = options.RemoteIPEndPoint,
                SessionId = Guid.NewGuid()
            };
            return session;
        }

        public async Task DisconnectAsync()
        {
            await AdapterMockServer.ConnectionServer.OnDisconnected(this);
        }

        public async Task ReadFromClientAsync(IDataBuffer buffer, CancellationToken token)
        {
            this.ServerStreamH.WaitOne();
            buffer.Length = await this.ServerStream.ReadAsync(buffer.Data, buffer.Length, buffer.Data.Length, token);
        }

        public async Task ReadFromServerAsync(IDataBuffer buffer, CancellationToken token)
        {
            this.ClientStreamH.WaitOne();
            buffer.Length = await this.ClientStream.ReadAsync(buffer.Data, buffer.Length, buffer.Data.Length, token);
        }

        public async Task WriteToClientAsync(IDataBuffer buffer, CancellationToken token)
        {
            await this.ClientStream.WriteAsync(buffer.Data, 0, buffer.Length, token);
            this.ClientStream.Position -= buffer.Length;
            this.ClientStreamH.Set();
        }

        public async Task WriteToServerAsync(IDataBuffer buffer, CancellationToken token)
        {
            await this.ServerStream.WriteAsync(buffer.Data, 0, buffer.Length, token);
            this.ServerStream.Position -= buffer.Length;
            this.ServerStreamH.Set();
        }

        public void Dispose()
        {
            this.ServerStream.Dispose();
            this.ClientStream.Dispose();
            this.ClientStreamH.Dispose();
            this.ServerStreamH.Dispose();
        }
    }
}