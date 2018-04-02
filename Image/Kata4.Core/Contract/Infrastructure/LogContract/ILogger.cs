using Kata4.Core.Contract.Enum;

namespace Kata4.Core.Contract.Infrastructure.LogContract
{
    public interface ILogger
    {
        string Name { get; }

        void Log(LogLevel logLevel, string message, System.Exception exception = null);
    }
}