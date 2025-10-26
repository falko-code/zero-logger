using BenchmarkDotNet.Attributes;
using Falko.Examples.Configurations;
using Falko.Logging.Factories;
using NLog;
using ZeroLogger = Falko.Logging.Loggers.Logger;
using NLogLogger = NLog.Logger;

namespace Falko.Examples.Benchmarks;

[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]
public class LogIgnoringBenchmark
{
    private static readonly ZeroLogger ZeroLogger = typeof(LogIgnoringBenchmark)
        .CreateLogger();

    private static readonly NLogLogger NLogLogger = LogManager
        .GetCurrentClassLogger();

    [Params(248, 512)]
    public int Iterations { get; set; }

    [Params(1, 3)]
    public int Targets { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        new WithoutRenderingLoggerConfigurer(Targets).Configure();
    }

    [Benchmark]
    public void LogZeroLogger()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Debug("Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark]
    public void LogZeroLoggerStatic()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            ZeroLogger.Debug(static () => "Iteration {IterationNumber}", iteration);
        }
    }

    [Benchmark(Baseline = true)]
    public void LogNLogLogger()
    {
        for (var iteration = 0; iteration < Iterations; iteration++)
        {
            NLogLogger.Debug("Iteration {IterationNumber}", iteration);
        }
    }
}
