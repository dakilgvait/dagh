namespace DAGH.Core.Abstractions
{
    public interface IEvent
    {
        void Subscribe();

        void UnSubscribe();
    }
}