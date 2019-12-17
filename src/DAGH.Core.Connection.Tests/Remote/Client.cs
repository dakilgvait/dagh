using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Factory.TCP.Tests.Mock;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Remote
{
    public class Client
    {
        public Client(ITestOutputHelper output)
        {
            this.MockServiceProvider = MockInitializer.GetIServiceProvider();
        }

        private IServiceProvider MockServiceProvider { get; }

        [Fact]
        public void Instance()
        {
            var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
            Assert.NotNull(client);
        }

        [Fact]
        public void Options()
        {
            var client = (IRemoteClient<MemoryStream>)MockServiceProvider.GetService(typeof(IRemoteClient<MemoryStream>));
            Assert.NotNull(client.Options);
        }
    }
}