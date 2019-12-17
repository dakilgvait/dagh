using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Factory.TCP.Tests.Mock;
using System;
using System.IO;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Remote
{
    public partial class Connection
    {
        public class WithoutServer
        {
            public WithoutServer(ITestOutputHelper output)
            {
                this.MockServiceProvider = MockInitializer.GetIServiceProvider();
            }

            private IServiceProvider MockServiceProvider { get; }

            [Fact]
            public void Instance()
            {
                var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
                Assert.NotNull(client.Connection);
            }

            [Fact]
            public void Connect()
            {
                var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
                var session = client.ConnectAsync().GetAwaiter().GetResult();
                Assert.Null(session);
            }

            [Fact]
            public void Stop()
            {
                var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
                client.DisconnectAsync().GetAwaiter().GetResult();
                Assert.Null(client);
            }

            [Fact]
            public void Read()
            {
                var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
                client.Connection.ReadAsync(null, default(CancellationToken)).GetAwaiter().GetResult();
                Assert.Null(client);
            }

            [Fact]
            public void Write()
            {
                var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
                client.Connection.WriteAsync(null, default(CancellationToken)).GetAwaiter().GetResult();
                Assert.Null(client);
            }
        }
    }
}