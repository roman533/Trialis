namespace Trialis.Services;

public sealed class LoggingService
{
    private static readonly object padlock = new object();
    private static LoggingService instance = null;

    private LoggingService()
    {
    }

    public static LoggingService Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new LoggingService();
                }

                return instance;
            }
        }
    }

    public void Log(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    }
}