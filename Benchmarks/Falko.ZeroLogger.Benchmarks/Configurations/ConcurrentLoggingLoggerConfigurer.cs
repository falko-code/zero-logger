using Falko.Examples.Targets;
using Falko.Logging.Builders;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using Falko.Logging.Targets;
using NLog;
using NLog.Config;
using NLog.Targets.Wrappers;
using LogLevel = NLog.LogLevel;

namespace Falko.Examples.Configurations;

public sealed class ConcurrentLoggingLoggerConfigurer(int capacity) : LoggerConfigurer
{
    protected override void ConfigureZeroLogger()
    {
        var loggerBuilder = new LoggerContextBuilder();

        loggerBuilder.SetLevel(LogLevels.InfoAndAbove);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance
                .AsConcurrent(capacity));

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance
                .AsConcurrent(capacity));

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance
                .AsConcurrent(capacity));

        LoggerRuntime.Global.Initialize(loggerBuilder);
    }

    protected override void ConfigureNLogLogger()
    {
        var configuration = new LoggingConfiguration();

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new AsyncTargetWrapper(new WithoutRenderingNLogLoggerTarget(0), capacity,
                AsyncTargetWrapperOverflowAction.Block));

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new AsyncTargetWrapper(new WithoutRenderingNLogLoggerTarget(1), capacity,
                AsyncTargetWrapperOverflowAction.Block));

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new AsyncTargetWrapper(new WithoutRenderingNLogLoggerTarget(2), capacity,
                AsyncTargetWrapperOverflowAction.Block));

        LogManager.Configuration = configuration;
    }
}
