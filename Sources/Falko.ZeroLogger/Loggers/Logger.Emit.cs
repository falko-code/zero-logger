using System.ComponentModel;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Numerics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace System.Logging.Loggers;

public readonly partial struct Logger
{
    #region Log()

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level,
                messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception,
                messageFactory);
        }
    }

    #endregion

    #region Log(State)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug<T>(LogLevel level,T messageState, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level,
                messageState, messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug<T>(LogLevel level, Exception? exception, T messageState, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception,
                messageState, messageFactory);
        }
    }

    #endregion

    #region Log(short)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ushort)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(int)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(uint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nuint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(long)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ulong)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(BigInteger)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(float)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(double)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(decimal)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(Guid)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeSpan)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTime)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTimeOffset)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(byte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(sbyte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(char)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(string, string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(string...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(T)

    public void Emit<T>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(T, T)

    public void Emit<T1, T2>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(T, T, T)

    public void Emit<T1, T2, T3>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(T, T, T, T)

    public void Emit<T1, T2, T3, T4>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(object...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(LogMessageArgument)

    public void Emit<T>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
                argument);
        }
    }

    public void Emit<T>(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument)

    public void Emit<T1, T2>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2);
        }
    }

    public void Emit<T1, T2>(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Emit<T1, T2, T3>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Emit<T1, T2, T3>(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Emit<T1, T2, T3, T4>(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Emit<T1, T2, T3, T4>(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, messageFactory,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, messageFactory,
            argumentFactory);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, [Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Emit(LogLevel level, Exception? exception, LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.Level.IsEnabled(level))
        {
            Log(loggerContext, level, exception, message,
                argumentFactories);
        }
    }

    #endregion
}
