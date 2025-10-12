> [!WARNING]
> This project is under active development. The underlying C# libraries are subject to change.

# Zero Logger

![NuGet Version](https://img.shields.io/nuget/v/Falko.ZeroLogger?style=for-the-badge&color=green)
![NuGet Version](https://img.shields.io/nuget/vpre/Falko.ZeroLogger?style=for-the-badge&color=red)
![SDK Version](https://img.shields.io/badge/.NET-8%2C9%2C10-gray?style=for-the-badge)
![CSharp Version](https://img.shields.io/badge/CSharp-13-gray?style=for-the-badge)
![GitHub License](https://img.shields.io/github/license/falko-code/zero-logger?style=for-the-badge&color=gray)

High-performance static structured logger with minimal allocations.

```C#
using var loggerRuntime = new LoggerRuntime().Initialize(builder => builder
    .SetLevel(LogLevels.InfoAndAbove)
    .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
    .AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("app_name", "./Logs")));

var logger = typeof(Program).CreateLogger(loggerRuntime);

logger.Info(static () => "PI is {PI}", static () => Math.PI.ToString("F"));
```

## Performance

Compare the performance of the **Zero Logger** with the **NLog Logger**.

```console
BenchmarkDotNet v0.15.2, Linux Rocky Linux 10.0 (Red Quartz)
AMD EPYC-Rome Processor, 1 CPU, 1 logical core and 1 physical core
.NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
.NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
GC=Concurrent Workstation
HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT VectorSize=256
gcc (GCC) 14.2.1 20250110 (Red Hat 14.2.1-7)
LLD 19.1.7 (compatible with GNU linkers)
```

| Method                       | Runtime       |       Mean |   Ratio |   Allocated |   Alloc Ratio |
|------------------------------|---------------|-----------:|--------:|------------:|--------------:|
| RenderZeroLoggerLog          | .NET 9.0      |   16.57 us |    0.45 |     25.7 KB |          0.51 |
| RenderZeroLoggerHandlingLog  | .NET 9.0      |   16.82 us |    0.46 |    24.14 KB |          0.48 |
| RenderZeroLoggerStaticLog    | .NET 9.0      |   16.20 us |    0.44 |     25.7 KB |          0.51 |
| RenderNLogLoggerLog          | .NET 9.0      |   36.73 us |    1.00 |    50.78 KB |          1.00 |
|                              |               |            |         |             |               |
| RenderZeroLoggerLog          | NativeAOT 9.0 |   17.17 us |    0.51 |     25.7 KB |          0.51 |
| RenderZeroLoggerHandlingLog  | NativeAOT 9.0 |   17.16 us |    0.51 |    24.14 KB |          0.48 |
| RenderZeroLoggerStaticLog    | NativeAOT 9.0 |   16.48 us |    0.49 |     25.7 KB |          0.51 |
| RenderNLogLoggerLog          | NativeAOT 9.0 |   33.98 us |    1.00 |    50.78 KB |          1.00 |
|                              |               |            |         |             |               |
| RenderZeroLoggerLog          | .NET 8.0      |   19.03 us |    0.51 |     25.7 KB |          0.51 |
| RenderZeroLoggerHandlingLog  | .NET 8.0      |   21.06 us |    0.57 |    24.14 KB |          0.48 |
| RenderZeroLoggerStaticLog    | .NET 8.0      |   19.58 us |    0.53 |     25.7 KB |          0.51 |
| RenderNLogLoggerLog          | .NET 8.0      |   37.27 us |    1.00 |    50.78 KB |          1.00 |
|                              |               |            |         |             |               |
| RenderZeroLoggerLog          | NativeAOT 8.0 |   19.03 us |    0.49 |     25.7 KB |          0.51 |
| RenderZeroLoggerHandlingLog  | NativeAOT 8.0 |   20.78 us |    0.54 |    24.14 KB |          0.48 |
| RenderZeroLoggerStaticLog    | NativeAOT 8.0 |   19.13 us |    0.50 |     25.7 KB |          0.51 |
| RenderNLogLoggerLog          | NativeAOT 8.0 |   38.55 us |    1.00 |    50.78 KB |          1.00 |

## License

This project is licensed under the **[GNU General Public License v3.0](License.md)**.

**© 2025, Falko**
