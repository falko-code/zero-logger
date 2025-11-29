using Falko.Logging.Factories;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using Falko.Logging.Targets;

using var loggerRuntime = LoggerRuntime.Global.Initialize(builder => builder
    .SetLevel(LogLevels.DebugAndAbove)
    .AddTarget(SimpleLogContextRenderer.Instance,
        LoggerConsoleTarget.Instance
            .AsConcurrent())
    .AddTarget(SimpleLogContextRenderer.Instance,
        new LoggerFileTarget("program", "./Logs")
            .AsConcurrent()));

var logger = typeof(Program).CreateLogger();

logger.Info("App started");

logger.Debug("LoggingTime is {LoggingTime} and RenderingTime is {RenderingTime}",
    LogMessageArgument.Create(DateTime.Now, static dateTime => dateTime.TimeOfDay.ToString()),
    LogMessageArgument.Create(static () => DateTime.Now.TimeOfDay.ToString()));

try
{
    throw new InvalidOperationException("Sample exception");
}
catch (Exception exception)
{
    logger.Error(exception, "Error occurred");
}
