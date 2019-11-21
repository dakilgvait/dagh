using DAGH.Core.Abstractions.Adapters;
using DAGH.Core.Adapter.Log4net;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System.Threading.Tasks;

namespace DAGH.Core.Adapter.log4net
{
    public class AdapterLoggerLog4net : IAdapterLogger
    {
        static AdapterLoggerLog4net()
        {
            AdapterLoggerLog4net.Hierarchy = AdapterLoggerLog4net.CreateHierarchy();
            AdapterLoggerLog4net.AddAppender(new GlobalRollingFileAppender());
        }

        public AdapterLoggerLog4net(ILoggerOptions options, string name)
        {
            this.Options = options;
            this.Logger = LogManager.GetLogger(Log4netOptions.DefaultRepositoryName, name);
        }

        public AdapterLoggerLog4net(ILoggerOptions options)
            : this(options, Log4netOptions.DefaultLoggerName) { }

        public ILoggerOptions Options { get; }
        protected static Hierarchy Hierarchy { get; }

        protected ILog Logger { get; }

        public static void AddAppender(IAppender appender)
        {
            AdapterLoggerLog4net.Hierarchy.Root.AddAppender(appender);
        }

        public Task DebugAsync(object msg)
        {
            return Task.Run(() =>
            {
                this.Logger.Debug(msg);
            });
        }

        public Task ErrorAsync(object msg)
        {
            return Task.Run(() =>
            {
                this.Logger.Error(msg);
            });
        }

        public Task InfoAsync(object msg)
        {
            return Task.Run(() =>
            {
                this.Logger.Info(msg);
            });
        }

        public Task WarnAsync(object msg)
        {
            return Task.Run(() =>
            {
                this.Logger.Warn(msg);
            });
        }

        private static Hierarchy CreateHierarchy()
        {
            var hierarchy = (Hierarchy)LogManager.CreateRepository(Log4netOptions.DefaultRepositoryName);
            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
            XmlConfigurator.Configure(hierarchy);
            return hierarchy;
        }
    }
}