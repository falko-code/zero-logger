using Falko.Examples.Targets;
using Falko.Logging.Builders;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using NLog;
using NLog.Config;
using LogLevel = NLog.LogLevel;

namespace Falko.Examples.Configurations;

public sealed class WithoutRenderingLoggerConfigurer(int targetsCount) : LoggerConfigurer
{
    protected override void ConfigureZeroLogger()
    {
        var loggerBuilder = new LoggerContextBuilder();

        loggerBuilder.SetLevel(LogLevels.InfoAndAbove);

        for (var i = 0; i < targetsCount; i++)
        {
            loggerBuilder.AddTarget(SimpleLogContextRenderer.Instance,
                WithoutRenderingZeroLoggerTarget.Instance);
        }

        LoggerRuntime.Global.Initialize(loggerBuilder);
    }

    protected override void ConfigureNLogLogger()
    {
        var configuration = new LoggingConfiguration();

        for (var i = 0; i < targetsCount; i++)
        {
            configuration.AddRule(LogLevel.Info, LogLevel.Fatal,
                new WithoutRenderingNLogLoggerTarget(i));
        }

        LogManager.Configuration = configuration;
    }
}
