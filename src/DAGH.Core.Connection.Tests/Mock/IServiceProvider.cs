using DAGH.Core.Abstractions.Connection.Remote;
using DAGH.Core.Connection.Factory.Mock;
using Moq;
using System;
using System.IO;

namespace DAGH.Core.Connection.Factory.TCP.Tests.Mock
{
    public static partial class MockInitializer
    {
        public static IServiceProvider GetIServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(IRemoteClient<MemoryStream>))).Returns(new RemoteClientMock(new RemoteOptions()));
            serviceProvider.Setup(x => x.GetService(typeof(IRemoteServer<MemoryStream>))).Returns(new RemoteServerMock(new RemoteOptions()));
            return serviceProvider.Object;
        }
    }
}