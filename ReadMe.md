# Zero Logger - Static Logger with Minimal Allocations

> The project is under active development. The underlying C# libraries are subject to change.

High-Performance Static Structured Logger with Minimal Allocations.

```C#
using var loggerRuntime = LoggerRuntime.Global;

loggerRuntime.Initialize(new LoggerContextBuilder()
    .SetLevel(LogLevels.InfoAndAbove)
    .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
    .AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("app_name", "./Logs")));

var logger = typeof(Program).CreateLogger();

logger.Info(static () => "PI is {PI}", static () => Math.PI.ToString("F"));
```

## Performance

Compare the performance of the Zero Logger with the NLog library.

### Performance with One Hundred Dynamic Log Message Iterations with Same Static Layout for Three Rendering Only Targets

```bash
BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC-Rome Processor, 1 CPU, 2 logical cores and 1 physical core
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  Job-SNMXOO : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX2
  Job-MBMBBG : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
RunStrategy=Throughput
```

| Method                      | Runtime       | Mean     | Ratio | Allocated | Alloc Ratio |
|---------------------------- |-------------- |---------:|------:|----------:|------------:|
| RenderZeroLoggerLog         | .NET 9.0      | 17.49 us |  0.38 |   25.7 KB |        0.24 |
| RenderZeroLoggerHandlingLog | .NET 9.0      | 18.54 us |  0.40 |  24.14 KB |        0.23 |
| RenderZeroLoggerStaticLog   | .NET 9.0      | 16.72 us |  0.36 |   25.7 KB |        0.24 |
| RenderNLogLoggerLog         | .NET 9.0      | 46.11 us |  1.00 | 105.47 KB |        1.00 |
|                             |               |          |       |           |             |
| RenderZeroLoggerLog         | .NET 8.0      | 18.67 us |  0.39 |   25.7 KB |        0.24 |
| RenderZeroLoggerHandlingLog | .NET 8.0      | 22.10 us |  0.46 |  24.14 KB |        0.23 |
| RenderZeroLoggerStaticLog   | .NET 8.0      | 18.78 us |  0.39 |   25.7 KB |        0.24 |
| RenderNLogLoggerLog         | .NET 8.0      | 48.20 us |  1.00 | 105.47 KB |        1.00 |



## License

This project is licensed under the [GNU General Public License v3.0](License.md).

**© 2025, Falko**
