using DAGH.Core.Abstractions.Adapters;
using DAGH.Core.Abstractions.Connection;
using DAGH.Core.Abstractions.Models;
using DAGH.Core.Adapter.Unity;
using DAGH.Core.Connection.Factory.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DAGH.Core.Connection.Factory.TCP.Tests
{
    public class UnitTest
    {
        private readonly IFactoryRemoteConnection _factoryRemoteConnection;
        private readonly IAdapterContainer _container;
        private readonly ITestOutputHelper _output;

        public UnitTest(ITestOutputHelper output)
        {
            var container = new AdapterContainerUnity();
            this._factoryRemoteConnection = container.Resolve<FactoryConnectionMock>();
            this._container = container;
            this._output = output;
            LocalOptionsMock optionsMock = new LocalOptionsMock();
            IAdapterRemoteServer server = this._factoryRemoteConnection.CreateServer(optionsMock);
            server.ConnectedActionAsync = this.Server_ConnectedActionAsync;

            server.StartAsync();
        }

        private async Task Server_ConnectedActionAsync(IAdapterRemoteClient connectionClient)
        {
            HandleAsync(connectionClient);
        }

        private Task HandleAsync(IAdapterRemoteClient connectionClient)
        {
            return Task.Run(async () =>
            {
                var buffer = new DataBuffer(255);
                using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                {
                    var byteData = new byte[] { 0, 255 };
                    await connectionClient.ReadFromClientAsync(buffer, tokenSource.Token);
                    await connectionClient.WriteToClientAsync(buffer, tokenSource.Token);
                }
            });
        }

        private Task DO(IAdapterRemoteClient connectionClient)
        {
            return Task.Run(async () =>
            {
                var buffer = new DataBuffer(255);
                using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                {
                    var byteData = new byte[] { 0, 255 };
                    await connectionClient.ReadFromClientAsync(buffer, tokenSource.Token);
                    await connectionClient.WriteToClientAsync(buffer, tokenSource.Token);
                }
            });
        }

        [Fact]
        public void Test_1()
        {
            List<Task> list = new List<Task>(1);
            RemoteOptionsMock optionsMock = new RemoteOptionsMock();
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(this.Run(optionsMock));
            }
            Task.WhenAll(list).Wait();
            Task t = list.Where(x => x.IsFaulted).FirstOrDefault();
            Assert.True(t == null, t?.Exception?.InnerException.Message);
        }

        protected Task Run(IRemoteOptions options)
        {
            return Task.Run(async () =>
            {
                using (IAdapterRemoteClient client = this._factoryRemoteConnection.CreateClient())
                using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                {
                    var byteData = new byte[] { 0, 255 };
                    try
                    {
                        await client.ConnectAsync(options);
                    }
                    catch (Exception e)
                    {
                        var q = e;
                    }
                    await client.WriteToServerAsync(new DataBuffer(byteData), tokenSource.Token);
                    var d = new DataBuffer(byteData.Length);
                    await client.ReadFromServerAsync(d, tokenSource.Token);
                }
            });
        }
    }
}