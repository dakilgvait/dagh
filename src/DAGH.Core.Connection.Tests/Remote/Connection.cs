using DAGH.Core.Abstractions;
using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Factory.TCP.Tests.Mock;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Remote
{
    public partial class Connection
    {
        public Connection(ITestOutputHelper output)
        {
            var serviceProvider = MockInitializer.GetIServiceProvider();
            var remoteServer = (IRemoteServer<MemoryStream>)serviceProvider.GetService(typeof(IRemoteServer<MemoryStream>));
            remoteServer.ClientHandler += RemoteServer_ClientHandler;
            remoteServer.StartAsync().GetAwaiter().GetResult();

            this.RemoteServer = remoteServer;
            this.MockServiceProvider = serviceProvider;
        }

        private async Task RemoteServer_ClientHandler(IRemoteClient<MemoryStream> client)
        {
            await Task.CompletedTask;
        }

        private IServiceProvider MockServiceProvider { get; }
        private IRemoteServer<MemoryStream> RemoteServer { get; }

        [Fact]
        public void Instance()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                Assert.NotNull(client);
            }
        }

        [Fact]
        public void Connect()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                var session = client.ConnectAsync().GetAwaiter().GetResult();
                Assert.NotNull(session);
            }
        }

        [Fact]
        public void Stop()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                client.DisconnectAsync().GetAwaiter().GetResult();
                Assert.NotNull(client);
            }
        }

        [Fact]
        public void Read()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                client.ConnectAsync().GetAwaiter().GetResult();
                var buffer = new DataBuffer(128);
                client.Connection.ReadAsync(buffer, default(CancellationToken)).GetAwaiter().GetResult();

                Assert.NotNull(client);
            }
        }

        [Fact]
        public void Write()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                client.ConnectAsync().GetAwaiter().GetResult();
                var buffer = new DataBuffer(128);
                client.Connection.WriteAsync(buffer, default(CancellationToken)).GetAwaiter().GetResult();
                Assert.NotNull(client);
            }
        }

        [Fact]
        public void WriteAndRead()
        {
            using (var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>)))
            {
                client.ConnectAsync().GetAwaiter().GetResult();
                var buffer1 = new DataBuffer(128);
                var buffer2 = new DataBuffer(128);
                client.Connection.WriteAsync(buffer1, default(CancellationToken)).GetAwaiter().GetResult();
                client.Connection.ReadAsync(buffer2, default(CancellationToken)).GetAwaiter().GetResult();
                Assert.NotNull(client);
            }
        }
    }
}