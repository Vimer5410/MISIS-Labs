namespace DefaultNamespace;

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger() 
    {
        Console.WriteLine("[Singleton] Logger создан");
    }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }
    }

    public void Log(string message) => Console.WriteLine($"[LOG]: {message}");
    
}
