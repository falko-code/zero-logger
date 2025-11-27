using System.ComponentModel;
using System.Numerics;
using Falko.Logging.Factories;
using Falko.Logging.Logs;
using JetBrains.Annotations;

namespace Falko.Logging.Loggers;

public readonly partial struct Logger
{
    #region Log()

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug,
                messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception,
                messageFactory);
        }
    }

    #endregion

    #region Log(State)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug<T>(T messageState, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug,
                messageState, messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug<T>(Exception? exception, T messageState, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception,
                messageState, messageFactory);
        }
    }

    #endregion

    #region Log(short)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ushort)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(int)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(uint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nuint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(long)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ulong)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(BigInteger)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(float)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(double)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(decimal)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(Guid)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeSpan)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTime)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTimeOffset)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(byte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(sbyte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(char)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(string, string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(string...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(T)

    public void Debug<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    public void Debug<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    public void Debug<T>(LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    public void Debug<T>(Exception? exception, LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(T, T)

    public void Debug<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(T, T, T)

    public void Debug<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(T, T, T, T)

    public void Debug<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(object...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(LogMessageArgument)

    public void Debug<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument);
        }
    }

    public void Debug<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument);
        }
    }

    public void Debug<T>(LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
                argument);
        }
    }

    public void Debug<T>(Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument)

    public void Debug<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2);
        }
    }

    public void Debug<T1, T2>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Debug<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Debug<T1, T2, T3>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Debug<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Debug<T1, T2, T3, T4>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, messageFactory,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, messageFactory,
            argumentFactory);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug([Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Debug(Exception? exception, LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsDebugLevelEnabled)
        {
            Log(loggerContext, LogLevel.Debug, exception, message,
                argumentFactories);
        }
    }

    #endregion
}
