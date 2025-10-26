using BenchmarkDotNet.Attributes;
using Falko.Examples.Configurations;
using Falko.Logging.Factories;
using NLog;
using ZeroLogger = Falko.Logging.Loggers.Logger;
using NLogLogger = NLog.Logger;

namespace Falko.Examples.Benchmarks;

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class LogConcurrentBenchmark
{
    private static readonly ZeroLogger ZeroLogger = typeof(LogConcurrentBenchmark)
        .CreateLogger();

    private static readonly NLogLogger NLogLogger = LogManager
        .GetCurrentClassLogger();

    [Params(248, 512)]
    public int Iterations { get; set; }

    [Params(248, 512)]
    public int Capacity { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        new ConcurrentLoggingLoggerConfigurer(Capacity).Configure();
    }

    [Benchmark]
    public void RenderZeroLoggerLog()
    {
        Parallel.For(0, Iterations, iteration =>
        {
            ZeroLogger.Info("Iteration {IterationNumber}", iteration);
        });
    }

    [Benchmark]
    public void RenderZeroLoggerStaticLog()
    {
        Parallel.For(0, Iterations, iteration =>
        {
            ZeroLogger.Info(static () => "Iteration {IterationNumber}", iteration);
        });
    }

    [Benchmark(Baseline = true)]
    public void RenderNLogLoggerLog()
    {
        Parallel.For(0, Iterations, iteration =>
        {
            NLogLogger.Info("Iteration {IterationNumber}", iteration);
        });
    }
}
