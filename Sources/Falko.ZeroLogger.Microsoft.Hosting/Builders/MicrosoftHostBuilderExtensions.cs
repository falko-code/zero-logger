using System.Logging.Factories;
using System.Logging.Loggers;
using System.Logging.Runtimes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace System.Logging.Builders;

public static class MicrosoftHostBuilderExtensions
{
    public static IMicrosoftHostBuilder UseZeroLogger(this IMicrosoftHostBuilder builder, LoggerRuntime loggerRuntime)
    {
        builder.ConfigureServices((_, services) =>
        {
            var loggerFactory = new MicrosoftLoggerFactory(loggerRuntime, disposeLoggerRuntime: false);

            services.RemoveAll<IMicrosoftLoggerFactory>();
            services.AddSingleton<IMicrosoftLoggerFactory>(loggerFactory);

            services.RemoveAll(typeof(ILogger<>));
            services.AddSingleton(typeof(ILogger<>), typeof(MicrosoftLogger<>));

            services.TryAddSingleton(loggerRuntime);
        });

        return builder;
    }
}
