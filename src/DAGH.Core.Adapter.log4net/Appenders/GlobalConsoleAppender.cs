using DAGH.Core.Adapter.Log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using System;

namespace DAGH.Core.Adapter.log4net
{
    public class GlobalConsoleAppender : ManagedColoredConsoleAppender
    {
        public GlobalConsoleAppender()
        {
            this.Name = Log4netOptions.DefaultRepositoryName;
            this.Layout = this.GetLayout();
            this.InitializeColor();
            this.ActivateOptions();
        }

        protected PatternLayout GetLayout()
        {
            PatternLayout layout = new PatternLayout(Log4netTemplate.GetTemplate());
            layout.ActivateOptions();
            return layout;
        }

        protected void InitializeColor()
        {
            this.AddMapping(new ManagedColoredConsoleAppender.LevelColors
            {
                Level = Level.Info,
                ForeColor = ConsoleColor.Cyan
            });
            this.AddMapping(new ManagedColoredConsoleAppender.LevelColors
            {
                Level = Level.Debug,
                ForeColor = ConsoleColor.Green
            });
            this.AddMapping(new ManagedColoredConsoleAppender.LevelColors
            {
                Level = Level.Warn,
                ForeColor = ConsoleColor.Yellow
            });
            this.AddMapping(new ManagedColoredConsoleAppender.LevelColors
            {
                Level = Level.Error,
                ForeColor = ConsoleColor.Red
            });
            this.AddMapping(new ManagedColoredConsoleAppender.LevelColors
            {
                Level = Level.Fatal,
                ForeColor = ConsoleColor.White,
                BackColor = ConsoleColor.Red
            });
        }
    }
}