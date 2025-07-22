﻿namespace BestPractices.Api.Logging
{
    public class MyCustomLoggerProvider : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class MyCustomLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string logMsg = formatter(state, exception);

            logMsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logMsg}";

            Console.WriteLine(logMsg);
        }
    }
}
