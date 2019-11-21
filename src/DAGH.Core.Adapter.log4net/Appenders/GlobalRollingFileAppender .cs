using DAGH.Core.Adapter.Log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;

namespace DAGH.Core.Adapter.log4net
{
    public class GlobalRollingFileAppender : RollingFileAppender
    {
        public GlobalRollingFileAppender()
        {
            var options = new Log4netOptions();
            this.Name = Log4netOptions.DefaultRepositoryName;
            this.File = options.File;
            this.DatePattern = options.DatePattern;
            this.AppendToFile = true;
            this.StaticLogFileName = false;
            this.RollingStyle = RollingFileAppender.RollingMode.Date;
            this.Layout = this.GetLayout();
            this.AddFilter(this.GetLevelRangeFilter());
            this.ActivateOptions();
        }

        protected PatternLayout GetLayout()
        {
            PatternLayout layout = new PatternLayout(Log4netTemplate.GetTemplate());
            layout.ActivateOptions();
            return layout;
        }

        protected LevelRangeFilter GetLevelRangeFilter()
        {
            LevelRangeFilter filter = new LevelRangeFilter()
            {
                LevelMin = Level.Warn,
                LevelMax = Level.Error
            };
            filter.ActivateOptions();
            return filter;
        }
    }
}