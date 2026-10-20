using System;

namespace Laba_4.Patterns.Common
{
    // тута синглтон
    public class GameLogger
    {
        private static GameLogger? _instance;
        private static readonly object _lock = new object();

        private GameLogger()
        {
            Console.WriteLine("[Singleton] GameLogger создан");
        }

        public static GameLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new GameLogger();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message) => Console.WriteLine($"[LOG]: {message}");
    }
}