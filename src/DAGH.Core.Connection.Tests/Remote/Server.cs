using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Factory.TCP.Tests.Mock;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Remote
{
    public class Server
    {
        public Server(ITestOutputHelper output)
        {
            this.MockServiceProvider = MockInitializer.GetIServiceProvider();
        }

        private IServiceProvider MockServiceProvider { get; }

        [Fact]
        public void Instance()
        {
            var server = (IRemoteServer<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteServer<MemoryStream>));
            Assert.NotNull(server);
        }

        [Fact]
        public void Options()
        {
            var server = (IRemoteServer<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteServer<MemoryStream>));
            Assert.NotNull(server.Options);
        }
    }
}