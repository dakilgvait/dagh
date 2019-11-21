namespace DAGH.Core.Adapter.Log4net
{
    public class Log4netOptions
    {
        public const string DefaultLoggerName = "GlobalLogger";
        public const string DefaultRepositoryName = "GlobalRepository";
        public string DatePattern { get; set; } = "yyyyMMdd'.log'";
        public string File { get; set; } = @"c:\logs\";
    }
}