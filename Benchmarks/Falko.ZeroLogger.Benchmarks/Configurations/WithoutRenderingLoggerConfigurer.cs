using Falko.Examples.Targets;
using Falko.Logging.Builders;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using NLog;
using NLog.Config;
using LogLevel = NLog.LogLevel;

namespace Falko.Examples.Configurations;

public sealed class WithoutRenderingLoggerConfigurer : LoggerConfigurer
{
    public static readonly WithoutRenderingLoggerConfigurer Instance = new();

    private WithoutRenderingLoggerConfigurer() { }

    protected override void ConfigureZeroLogger()
    {
        var loggerBuilder = new LoggerContextBuilder();

        loggerBuilder.SetLevel(LogLevels.InfoAndAbove);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance);

        loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
            WithoutRenderingZeroLoggerTarget.Instance);

        LoggerRuntime.Global.Initialize(loggerBuilder);
    }

    protected override void ConfigureNLogLogger()
    {
        var configuration = new LoggingConfiguration();

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new WithoutRenderingNLogLoggerTarget(0));

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new WithoutRenderingNLogLoggerTarget(1));

        configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
            new WithoutRenderingNLogLoggerTarget(2));

        LogManager.Configuration = configuration;
    }
}
