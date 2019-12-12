using DAGH.Core.Abstractions.Connection;

namespace DAGH.Core.Connection.Factory.TCP
{
    public class FactoryTCP : IFactoryRemoteConnection
    {
        public IAdapterRemoteClient CreateClient()
        {
            return new AdapterTCPClient();
        }

        public IAdapterRemoteServer CreateServer(ILocalOptions options)
        {
            return new AdapterTCPServer(options);
        }
    }
}