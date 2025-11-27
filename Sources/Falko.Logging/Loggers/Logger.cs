using System.Numerics;
using System.Runtime.InteropServices;
using Falko.Logging.Contexts;
using Falko.Logging.Debugs;
using Falko.Logging.Factories;
using Falko.Logging.Logs;
using Falko.Logging.Providers;
using Falko.Logging.Renderers;
using Falko.Logging.Runtimes;
using Falko.Logging.Targets;

namespace Falko.Logging.Loggers;

[StructLayout(LayoutKind.Auto)]
public readonly partial struct Logger
{
    private readonly LoggerRuntime _loggerRuntime;

    private readonly string _loggerSource;

    private readonly IDateTimeOffsetProvider _timeProvider;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Logger(LoggerRuntime loggerRuntime, string loggerSource)
    {
        _loggerRuntime = loggerRuntime;
        _loggerSource = loggerSource;
        _timeProvider = DateTimeOffsetProvider.Current;
    }

    #region Log()

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleMessageLogMessageRenderer(message);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleMessageLogMessageRenderer(message);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleMessageFactoryLogMessageRenderer(messageFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleMessageFactoryLogMessageRenderer(messageFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(State)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level,
        T messageState, LogMessageFactory<T> messageFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new StateMessageFactoryLogMessageRenderer<T>(messageFactory, messageState);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, Exception? exception,
        T messageState, LogMessageFactory<T> messageFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new StateMessageFactoryLogMessageRenderer<T>(messageFactory, messageState);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(short)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        short argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<short>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        short argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<short>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        short argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<short>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        short argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<short>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(ushort)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        ushort argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<ushort>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        ushort argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<ushort>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        ushort argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<ushort>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        ushort argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<ushort>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(int)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        int argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<int>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        int argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<int>(message, argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        int argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<int>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        int argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<int>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(nint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        nint argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<nint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        nint argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<nint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        nint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<nint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        nint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<nint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(uint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        uint argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<uint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        uint argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<uint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        uint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<uint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        uint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<uint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(nuint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        nuint argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<nuint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        nuint argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<nuint>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        nuint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<nuint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        nuint argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<nuint>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(long)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        long argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<long>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        long argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<long>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        long argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<long>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        long argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<long>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(ulong)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        ulong argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<ulong>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        ulong argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<ulong>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        ulong argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<ulong>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        ulong argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<ulong>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(BigInteger)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        BigInteger argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<BigInteger>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        BigInteger argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<BigInteger>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<BigInteger>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<BigInteger>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(float)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        float argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<float>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        float argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<float>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        float argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<float>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        float argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<float>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(double)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        double argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<double>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        double argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<double>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        double argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<double>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        double argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<double>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(decimal)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        decimal argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<decimal>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        decimal argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<decimal>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        decimal argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<decimal>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        decimal argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<decimal>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(Guid)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        Guid argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<Guid>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        Guid argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<Guid>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        Guid argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<Guid>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        Guid argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<Guid>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(TimeSpan)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        TimeSpan argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<TimeSpan>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        TimeSpan argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<TimeSpan>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<TimeSpan>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<TimeSpan>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(TimeOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        TimeOnly argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<TimeOnly>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        TimeOnly argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<TimeOnly>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<TimeOnly>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<TimeOnly>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(DateTime)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        DateTime argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateTime>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        DateTime argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateTime>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateTime>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateTime>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(DateTimeOffset)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        DateTimeOffset argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateTimeOffset>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        DateTimeOffset argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateTimeOffset>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateTimeOffset>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateTimeOffset>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(DateOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        DateOnly argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateOnly>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        DateOnly argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<DateOnly>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateOnly>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<DateOnly>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(byte)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        byte argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<byte>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        byte argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<byte>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        byte argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<byte>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        byte argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<byte>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(sbyte)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        sbyte argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<sbyte>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        sbyte argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<sbyte>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<sbyte>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<sbyte>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(char)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        char argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<char>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        char argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageLogMessageRenderer<char>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        char argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<char>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        char argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFormattableArgumentMessageFactoryLogMessageRenderer<char>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        string? argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleStringArgumentMessageLogMessageRenderer(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        string? argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleStringArgumentMessageLogMessageRenderer(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        string? argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleStringArgumentMessageFactoryLogMessageRenderer(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        string? argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleStringArgumentMessageFactoryLogMessageRenderer(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        string? argument1,
        string? argument2)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        string? argument1,
        string? argument2)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(string, string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourStringArgumentsMessageLogMessageRenderer(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(string...)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        params string?[] arguments)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyStringArgumentsMessageLogMessageRenderer(message,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        params string?[] arguments)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyStringArgumentsMessageLogMessageRenderer(message,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        params string?[] arguments)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        params string?[] arguments)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyStringArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, string? message,
        T argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleInstanceArgumentMessageLogMessageRenderer<T>(message, argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        T argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleInstanceArgumentMessageLogMessageRenderer<T>(message, argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        T argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleInstanceArgumentMessageFactoryLogMessageRenderer<T>(messageFactory, argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        T argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleInstanceArgumentMessageFactoryLogMessageRenderer<T>(messageFactory, argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider) { Exception = exception });
    }

    #endregion

    #region Log(T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, string? message,
        T1 argument1,
        T2 argument2)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoInstanceArgumentsMessageLogMessageRenderer<T1, T2>(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        T1 argument1,
        T2 argument2)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoInstanceArgumentsMessageLogMessageRenderer<T1, T2>(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2>(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2>(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(T, T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3>(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3>(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3>(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3>(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(T, T, T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3, T4>(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3, T4>(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3, T4>(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3, T4>(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(object...)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        params object?[] arguments)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyInstanceArgumentsMessageLogMessageRenderer(message,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        params object?[] arguments)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyInstanceArgumentsMessageLogMessageRenderer(message,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        params object?[] arguments)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyInstanceArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        params object?[] arguments)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyInstanceArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            arguments);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgument<T> argument)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleArgumentMessageLogMessageRenderer<T>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgument<T> argument)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleArgumentMessageLogMessageRenderer<T>(message,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleArgumentMessageFactoryLogMessageRenderer<T>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleArgumentMessageFactoryLogMessageRenderer<T>(messageFactory,
            argument);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoArgumentsMessageLogMessageRenderer<T1, T2>(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoArgumentsMessageLogMessageRenderer<T1, T2>(message,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoArgumentsMessageFactoryLogMessageRenderer<T1, T2>(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoArgumentsMessageFactoryLogMessageRenderer<T1, T2>(messageFactory,
            argument1,
            argument2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeArgumentsMessageLogMessageRenderer<T1, T2, T3>(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeArgumentsMessageLogMessageRenderer<T1, T2, T3>(message,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3>(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3>(messageFactory,
            argument1,
            argument2,
            argument3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourArgumentsMessageLogMessageRenderer<T1, T2, T3, T4>(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourArgumentsMessageLogMessageRenderer<T1, T2, T3, T4>(message,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3, T4>(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log<T1, T2, T3, T4>(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3, T4>(messageFactory,
            argument1,
            argument2,
            argument3,
            argument4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFactoryArgumentMessageLogMessageRenderer(message,
            argumentFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new SingleFactoryArgumentMessageLogMessageRenderer(message,
            argumentFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFactoryArgumentMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var time = _timeProvider.Now;

        var messageProvider = new SingleFactoryArgumentMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new TwoFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var time = _timeProvider.Now;

        var messageProvider = new TwoFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ThreeFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ThreeFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3,
            argumentFactory4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new FourFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3,
            argumentFactory4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3,
            argumentFactory4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var time = _timeProvider.Now;

        var messageProvider = new FourFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactory1,
            argumentFactory2,
            argumentFactory3,
            argumentFactory4);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    #region Log(LogMessageArgumentFactory...)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        if (message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactories);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        if (exception is null && message is null) return;

        var time = _timeProvider.Now;

        var messageProvider = new ManyFactoryArgumentsMessageLogMessageRenderer(message,
            argumentFactories);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, LogMessageFactory messageFactory,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactories);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Log(LoggerContext loggerContext, LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var time = _timeProvider.Now;

        var messageProvider = new ManyFactoryArgumentsMessageFactoryLogMessageRenderer(messageFactory,
            argumentFactories);

        PublishLog(loggerContext, new LogContext(_loggerSource, level, time, messageProvider)
        {
            Exception = exception
        });
    }

    #endregion

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
    private static void PublishLog(LoggerContext loggerContext, in LogContext logContext)
    {
        var targets = loggerContext.Targets;
        var renderers = loggerContext.Renderers;

        var targetsLength = targets.Length;

        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (targetsLength > 1)
        {
            var cancellationToken = loggerContext.CancellationToken;

            scoped ref var targetsRef = ref MemoryMarshal.GetArrayDataReference(targets);

            var renderersLength = renderers.Length;

            if (renderersLength > 1)
            {
                scoped ref var renderersRef = ref MemoryMarshal.GetArrayDataReference(loggerContext.Renderers);

                var targetIndex = 0;

                for (var rendererIndex = 0; rendererIndex < renderersLength; rendererIndex++)
                {
                    var renderersSpan = Unsafe.Add(ref renderersRef, rendererIndex);
                    var spanRenderers = renderersSpan.Count;

                    if (spanRenderers is 1)
                    {
                        var target = Unsafe.Add(ref targetsRef, targetIndex);

                        ++targetIndex;

                        PublishLog(target, logContext, renderersSpan.Renderer, cancellationToken);

                        continue;
                    }

                    var logRenderer = new PersistentLogContextRenderer(renderersSpan.Renderer);

                    for (var logRendererIndex = 0; logRendererIndex < spanRenderers; logRendererIndex++)
                    {
                        var target = Unsafe.Add(ref targetsRef, targetIndex);

                        ++targetIndex;

                        PublishLog(target, logContext, logRenderer, cancellationToken);
                    }
                }
            }
            else
            {
                var logRenderer = new PersistentLogContextRenderer(renderers[0].Renderer);

                for (var targetIndex = 0; targetIndex < targetsLength; targetIndex++)
                {
                    var target = Unsafe.Add(ref targetsRef, targetIndex);

                    PublishLog(target, logContext, logRenderer, cancellationToken);
                }
            }
        }
        else if (targetsLength is 1)
        {
            PublishLog(targets[0], logContext, renderers[0].Renderer, loggerContext.CancellationToken);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static void PublishLog(in LoggerTarget target, in LogContext logContext, ILogContextRenderer logRenderer,
        CancellationToken cancellationToken)
    {
        try
        {
            target.Publish(logContext, logRenderer, cancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle("Error while publishing log", exception);
        }
    }
}
