using Microsoft.Extensions.Logging;
using System;

namespace DotNetCorePayroll.Console
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose()
        {
           
        }

        private class MyLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
               return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
              System.Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
