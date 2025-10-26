using BenchmarkDotNet.Attributes;
using Falko.Examples.Configurations;
using Falko.Logging.Factories;
using NLog;
using ZeroLogger = Falko.Logging.Loggers.Logger;
using NLogLogger = NLog.Logger;

namespace Falko.Examples.Benchmarks;

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class LogWithRenderingBenchmark
{
    private static readonly ZeroLogger ZeroLogger = typeof(LogWithRenderingBenchmark)
        .CreateLogger();

    private static readonly NLogLogger NLogLogger = LogManager
        .GetCurrentClassLogger();

    [Params(248, 512)]
    public int Iterations { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        WithRenderingLoggerConfigurer.Instance
            .Configure();
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
