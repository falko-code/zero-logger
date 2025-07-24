using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<LogIgnoringBenchmark>();
BenchmarkRunner.Run<LogWritingBenchmark>();
BenchmarkRunner.Run<LogRenderingBenchmark>();

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net80)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot80)]
[MinColumn, MeanColumn, MaxColumn]
public class LogIgnoringBenchmark
{
    private static readonly System.Logging.Loggers.Logger ZeroLogger = System.Logging.Runtimes.LoggerRuntime.Global.LoggerFactory
        .CreateLoggerOfType<LogIgnoringBenchmark>();

    private static readonly NLog.Logger NLogLogger = NLog.LogManager
        .GetCurrentClassLogger();

    private const int Iterations = 100;

    [GlobalSetup]
    public void Setup()
    {
        RenderingLoggerConfigurer.Configure();
    }

    [Benchmark(Baseline = true)]
    public void IgnoreNLogLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            NLogLogger.Trace("Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark]
    public void IgnoreZeroLoggerStaticLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Trace(static () => "Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark]
    public void IgnoreZeroLoggerHandlingLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Trace($"Iteration {iteration}");
        }
    }

    [Benchmark]
    public void IgnoreZeroLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Trace("Iteration {IterationNumber}", iteration);
        }
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net80)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot80)]
[MinColumn, MeanColumn, MaxColumn]
public class LogRenderingBenchmark
{
    private static readonly System.Logging.Loggers.Logger ZeroLogger = System.Logging.Runtimes.LoggerRuntime.Global.LoggerFactory
        .CreateLoggerOfType<LogRenderingBenchmark>();

    private static readonly NLog.Logger NLogLogger = NLog.LogManager
        .GetCurrentClassLogger();

    private const int Iterations = 100;

    [GlobalSetup]
    public void Setup()
    {
        RenderingLoggerConfigurer.Configure();
    }

    [Benchmark]
    public void RenderZeroLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info("Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark]
    public void RenderZeroLoggerHandlingLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info($"Iteration {iteration}");
        }
    }

    [Benchmark]
    public void RenderZeroLoggerStaticLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info(static () => "Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark(Baseline = true)]
    public void RenderNLogLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            NLogLogger.Info("Iteration {IterationNumber}", iteration);
        }
    }
}

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net80)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot80)]
[MinColumn, MeanColumn, MaxColumn]
public class LogWritingBenchmark
{
    private static readonly System.Logging.Loggers.Logger ZeroLogger = System.Logging.Runtimes.LoggerRuntime.Global.LoggerFactory
        .CreateLoggerOfType<LogWritingBenchmark>();

    private static readonly NLog.Logger NLogLogger = NLog.LogManager
        .GetCurrentClassLogger();

    private const int Iterations = 100;

    [GlobalSetup]
    public void Setup()
    {
        EmptyLoggerConfigurer.Configure();
    }

    [Benchmark]
    public void RenderZeroLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info("Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark]
    public void RenderZeroLoggerHandlingLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info($"Iteration {iteration}");
        }
    }

    [Benchmark]
    public void RenderZeroLoggerStaticLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Info(static () => "Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark(Baseline = true)]
    public void RenderNLogLoggerLog()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            NLogLogger.Info("Iteration {IterationNumber}", iteration);
        }
    }
}

file static class RenderingLoggerConfigurer
{
    public static void Configure()
    {
        ConfigureZeroLogger();
        ConfigureNLogLogger();
    }

    private static void ConfigureZeroLogger()
    {
        System.Logging.Runtimes.LoggerRuntime.Global
            .Initialize(new System.Logging.Builders.LoggerContextBuilder()
                .SetLevel(System.Logging.Logs.LogLevels.InfoAndAbove)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    RenderingZeroLoggerTarget.Instance)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    RenderingZeroLoggerTarget.Instance)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    RenderingZeroLoggerTarget.Instance));
    }

    private static void ConfigureNLogLogger()
    {
        var configuration = new NLog.Config.LoggingConfiguration();

        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            RenderingNLogLoggerTarget.Instance);
        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            RenderingNLogLoggerTarget.Instance);
        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            RenderingNLogLoggerTarget.Instance);

        NLog.LogManager.Configuration = configuration;
    }
}

file sealed class RenderingZeroLoggerTarget : System.Logging.Targets.LoggerTarget
{
    public static readonly RenderingZeroLoggerTarget Instance = new();

    private RenderingZeroLoggerTarget() { }

    public override void Initialize(CancellationToken cancellationToken) { }

    public override void Publish(in System.Logging.Contexts.LogContext context,
        System.Logging.Renderers.ILogContextRenderer renderer,
        CancellationToken cancellationToken)
    {
        _ = renderer.Render(context);
    }

    public override void Dispose(CancellationToken cancellationToken) { }
}

file sealed class RenderingNLogLoggerTarget : NLog.Targets.TargetWithLayout
{
    public static readonly RenderingNLogLoggerTarget Instance = new()
    {
        Layout = "[${time}] [${level:uppercase=true}] [${logger}] ${message}",
    };

    private RenderingNLogLoggerTarget() { }

    protected override void Write(NLog.LogEventInfo logEvent)
    {
        _ = Layout.Render(logEvent);
    }
}

file static class EmptyLoggerConfigurer
{
    public static void Configure()
    {
        ConfigureZeroLogger();
        ConfigureNLogLogger();
    }

    private static void ConfigureZeroLogger()
    {
        System.Logging.Runtimes.LoggerRuntime.Global
            .Initialize(new System.Logging.Builders.LoggerContextBuilder()
                .SetLevel(System.Logging.Logs.LogLevels.InfoAndAbove)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    EmptyZeroLoggerTarget.Instance)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    EmptyZeroLoggerTarget.Instance)
                .AddTarget(System.Logging.Renderers.SimpleLogContextRenderer.Instance,
                    EmptyZeroLoggerTarget.Instance));
    }

    private static void ConfigureNLogLogger()
    {
        var configuration = new NLog.Config.LoggingConfiguration();

        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            EmptyNLogLoggerTarget.Instance);
        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            EmptyNLogLoggerTarget.Instance);
        configuration.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal,
            EmptyNLogLoggerTarget.Instance);

        NLog.LogManager.Configuration = configuration;
    }
}

file sealed class EmptyZeroLoggerTarget : System.Logging.Targets.LoggerTarget
{
    public static readonly EmptyZeroLoggerTarget Instance = new();

    private EmptyZeroLoggerTarget() { }

    public override void Initialize(CancellationToken cancellationToken) { }

    public override void Publish(in System.Logging.Contexts.LogContext context,
        System.Logging.Renderers.ILogContextRenderer renderer,
        CancellationToken cancellationToken)
    {
        _ = context;
    }

    public override void Dispose(CancellationToken cancellationToken) { }
}

file sealed class EmptyNLogLoggerTarget : NLog.Targets.TargetWithLayout
{
    public static readonly EmptyNLogLoggerTarget Instance = new()
    {
        Layout = "[${time}] [${level:uppercase=true}] [${logger}] ${message}",
    };

    private EmptyNLogLoggerTarget() { }

    protected override void Write(NLog.LogEventInfo logEvent)
    {
        _ = logEvent;
    }
}
