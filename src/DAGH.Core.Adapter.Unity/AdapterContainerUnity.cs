using DAGH.Core.Abstractions.Adapters;
using Unity;
using Unity.Resolution;

namespace DAGH.Core.Adapter.Unity
{
    public class AdapterContainerUnity : IAdapterContainer
    {
        public AdapterContainerUnity()
        {
            var container = new UnityContainer();
            this._container = container;
        }

        private IUnityContainer _container { get; }

        public void RegisterInstance<T>(T o)
        {
            this._container.RegisterInstance(o);
        }

        public void RegisterInstance<T>(string name, T o)
        {
            this._container.RegisterInstance(name, o);
        }

        public void RegisterSingleton<I, T>() where T : I
        {
            this._container.RegisterSingleton<I, T>();
        }

        public void RegisterSingleton<I, T>(string name) where T : I
        {
            this._container.RegisterSingleton<I, T>(name);
        }

        public void RegisterType<I, T>() where T : I
        {
            this._container.RegisterType<I, T>();
        }

        public void RegisterType<I, T>(string name) where T : I
        {
            this._container.RegisterType<I, T>(name);
        }

        public I Resolve<I>()
        {
            return this._container.Resolve<I>();
        }

        public I Resolve<I, P>(params P[] parameters)
        {
            return this._container.Resolve<I>(parameters as ParameterOverride[]);
        }
    }
}