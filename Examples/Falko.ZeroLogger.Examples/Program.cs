using System.Logging.Builders;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Renderers;
using System.Logging.Runtimes;
using System.Logging.Targets;

var builder = new LoggerContextBuilder();

builder.SetLevel(LogLevels.InfoAndAbove);

builder.AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance);
builder.AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("program", "./Logs"));

LoggerRuntime.Global.Initialize(builder);

var logger = LoggerFactory.Global.CreateLoggerOfType<Program>();

logger.Info(static () => "App started");
logger.Error(new Exception(), static () => "Error occurred");
logger.Debug(static () => "CurrentTime: {CurrentTime}", static () => DateTime.Now);

// Test the new OfClass methods
var classLogger1 = LoggerFactory.Global.CreateLoggerOfClass<Program>();
classLogger1.Info(static () => "Testing CreateLoggerOfClass<T>() - this should use 'Program' as logger name");

var classLogger2 = LoggerFactory.Global.CreateLoggerOfClass(typeof(Program));
classLogger2.Info(static () => "Testing CreateLoggerOfClass(Type) - this should also use 'Program' as logger name");

// Test with a different class type
var stringClassLogger = LoggerFactory.Global.CreateLoggerOfClass<string>();
stringClassLogger.Info(static () => "Testing with String class - should use 'String' as logger name");

LoggerRuntime.Global.Dispose();
