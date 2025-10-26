using BenchmarkDotNet.Running;
using Falko.Examples.Benchmarks;

BenchmarkRunner.Run<LogIgnoringBenchmark>();
BenchmarkRunner.Run<LogWithoutRenderingBenchmark>();
BenchmarkRunner.Run<LogWithRenderingBenchmark>();
BenchmarkRunner.Run<LogConcurrentBenchmark>();
