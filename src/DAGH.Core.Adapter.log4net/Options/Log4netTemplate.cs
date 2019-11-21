namespace DAGH.Core.Adapter.log4net
{
    public class Log4netTemplate
    {
        private const string date = "%date{hh:mm:ss.fff}";
        private const string level = "%-5level";
        private const string logger = "%logger";
        private const string message = "%message";
        private const string newline = "%newline";
        private const string thread = "[%thread]";

        public static string GetTemplate()
        {
            return $"{date} {thread}\t{level}\t{logger}\t{message}{newline}";
        }
    }
}