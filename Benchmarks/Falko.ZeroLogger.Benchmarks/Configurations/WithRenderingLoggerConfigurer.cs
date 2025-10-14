using Falko.Examples.Targets;
using Falko.Logging.Builders;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using NLog;
using NLog.Config;
using LogLevel = NLog.LogLevel;

namespace Falko.Examples.Configurations;

public sealed class WithRenderingLoggerConfigurer : LoggerConfigurer
{
    public static readonly WithRenderingLoggerConfigurer Instance = new();

    private WithRenderingLoggerConfigurer() { }

    protected override void ConfigureZeroLogger()
    {
        var loggerBuilder = new LoggerContextBuilder();

        loggerBuilder.SetLevel(LogLevels.InfoAndAbove);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithRenderingZeroLoggerTarget.Instance);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithRenderingZeroLoggerTarget.Instance);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithRenderingZeroLoggerTarget.Instance);

        LoggerRuntime.Global.Initialize(loggerBuilder);
    }

    protected override void ConfigureNLogLogger()
    {
        var configuration = new LoggingConfiguration();

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            WithRenderingNLogLoggerTarget.Instance);

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            WithRenderingNLogLoggerTarget.Instance);

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            WithRenderingNLogLoggerTarget.Instance);

        LogManager.Configuration = configuration;
    }
}
