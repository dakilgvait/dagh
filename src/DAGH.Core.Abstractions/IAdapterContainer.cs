namespace DAGH.Core.Abstractions.Adapters
{
    public interface IAdapterContainer
    {
        void RegisterInstance<T>(T o);

        void RegisterInstance<T>(string name, T o);

        void RegisterSingleton<I, T>() where T : I;

        void RegisterSingleton<I, T>(string name) where T : I;

        void RegisterType<I, T>() where T : I;

        void RegisterType<I, T>(string name) where T : I;

        I Resolve<I>();

        I Resolve<I, P>(params P[] overrides);
    }
}