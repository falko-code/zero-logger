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
    public void Warn(DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn,
                messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception,
                messageFactory);
        }
    }

    #endregion

    #region Log(short)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        short argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ushort)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        ushort argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(int)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        int argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        nint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(uint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        uint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(nuint)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        nuint argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(long)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        long argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(ulong)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        ulong argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(BigInteger)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        BigInteger argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(float)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        float argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(double)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        double argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(decimal)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        decimal argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(Guid)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        Guid argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeSpan)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        TimeSpan argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(TimeOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        TimeOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTime)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        DateTime argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateTimeOffset)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        DateTimeOffset argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(DateOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        DateOnly argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(byte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        byte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(sbyte)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        sbyte argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(char)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        char argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        string? argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(string, string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(string...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        params string?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(T)

    public void Warn<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    public void Warn<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    public void Warn<T>(LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    public void Warn<T>(Exception? exception, LogMessageFactory messageFactory,
        T argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(T, T)

    public void Warn<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(T, T, T)

    public void Warn<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(T, T, T, T)

    public void Warn<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(Exception? exception, LogMessageFactory message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(object...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        params object?[] arguments)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(LogMessageArgument)

    public void Warn<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument);
        }
    }

    public void Warn<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument);
        }
    }

    public void Warn<T>(LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
                argument);
        }
    }

    public void Warn<T>(Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgument<T> argument)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
                argument);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument)

    public void Warn<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2);
        }
    }

    public void Warn<T1, T2>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Warn<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3);
        }
    }

    public void Warn<T1, T2, T3>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument, LogMessageArgument)

    public void Warn<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    public void Warn<T1, T2, T3, T4>(Exception? exception, LogMessageFactory message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, messageFactory,
            argumentFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory messageFactory,
        LogMessageArgumentFactory argumentFactory)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, messageFactory,
            argumentFactory);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory, LogMessageArgumentFactory)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        LogMessageArgumentFactory argumentFactory1,
        LogMessageArgumentFactory argumentFactory2,
        LogMessageArgumentFactory argumentFactory3,
        LogMessageArgumentFactory argumentFactory4)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactory1,
                argumentFactory2,
                argumentFactory3,
                argumentFactory4);
        }
    }

    #endregion

    #region Log(LogMessageArgumentFactory...)

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn([Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, message,
                argumentFactories);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Warn(Exception? exception, LogMessageFactory message,
        params LogMessageArgumentFactory[] argumentFactories)
    {
        var loggerContext = _loggerRuntime.LoggerContext;

        if (loggerContext.IsWarnLevelEnabled)
        {
            Log(loggerContext, LogLevel.Warn, exception, message,
                argumentFactories);
        }
    }

    #endregion
}
