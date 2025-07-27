using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Renderers;
using System.Logging.Runtimes;
using System.Logging.Targets;
using Falko.Examples;

using var loggerRuntime = LoggerRuntime.Global.Initialize(builder => builder
    .SetLevel(LogLevels.DebugAndAbove)
    .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
    .AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("program", "./Logs")));

LoggableStaticClass.Init();
new LoggableInstanceClass().Init();

var logger = typeof(Program).CreateLogger();

logger.Trace(static () => "App started");
logger.Error(new Exception(), static () => "Error occurred");
logger.Info(static () => "CurrentTime: {CurrentTime}", static () => DateTime.Now.TimeOfDay.ToString());
