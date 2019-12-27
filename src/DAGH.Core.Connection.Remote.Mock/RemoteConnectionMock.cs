using DAGH.Core.Abstractions;
using DAGH.Core.Abstractions.Connection.Remote;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DAGH.Core.Connection.Remote.Mock
{
    public class RemoteConnectionMock : IRemoteConnection<MemoryStream>
    {
        public RemoteConnectionMock(MemoryStream stream, RemoteSession session)
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
}