using DAGH.Core.Abstractions.Connection;

namespace DAGH.Core.Connection.Factory.Mock
{
    public class FactoryConnectionMock : IFactoryRemoteConnection
    {
        public IAdapterRemoteClient CreateClient()
        {
            return new AdapterMockClient();
        }

        public IAdapterRemoteServer CreateServer(ILocalOptions options)
        {
            return new AdapterMockServer(options);
        }
    }
}