using Falko.Examples.Targets;
using Falko.Logging.Builders;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using NLog;
using NLog.Config;
using LogLevel = NLog.LogLevel;

namespace Falko.Examples.Configurations;

public sealed class WithRenderingLoggerConfigurer(int targetsCount) : LoggerConfigurer
{
    protected override void ConfigureZeroLogger()
    {
        var loggerBuilder = new LoggerContextBuilder();

        loggerBuilder.SetLevel(LogLevels.InfoAndAbove);

        for (var i = 0; i < targetsCount; i++)
        {
            loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
                WithRenderingZeroLoggerTarget.Instance);
        }

        LoggerRuntime.Global.Initialize(loggerBuilder);
    }

    protected override void ConfigureNLogLogger()
    {
        var configuration = new LoggingConfiguration();

        for (var i = 0; i < targetsCount; i++)
        {
            configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
                new WithRenderingNLogLoggerTarget(i));
        }

        LogManager.Configuration = configuration;
    }
}
