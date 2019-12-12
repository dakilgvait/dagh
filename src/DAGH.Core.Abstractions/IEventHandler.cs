namespace DAGH.Core.Abstractions
{
    public interface IEventHandler
    {
        void Subscribe();

        void UnSubscribe();
    }
}