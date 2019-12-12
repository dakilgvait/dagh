namespace DAGH.Core.Abstractions.Connection
{
    public interface IAdapterRemoteServer : IRunnable
    {
        ILocalOptions Options { get; }

        RemoteActionAsync ConnectedActionAsync { get; set; }

        RemoteActionAsync DisconnectedActionAsync { get; set; }
    }
}