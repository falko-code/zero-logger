using Falko.Examples;
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

LoggableStaticClass.Init();
new LoggableInstanceClass().Init();

var logger = typeof(Program).CreateLogger();

logger.Trace(static () => "App started");
logger.Error(new Exception(), static () => "Error occurred");
logger.Info(static () => "CurrentTime: {CurrentTime}", static () => DateTime.Now.TimeOfDay.ToString());
