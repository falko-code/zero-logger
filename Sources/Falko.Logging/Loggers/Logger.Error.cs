using System.ComponentModel;
using System.Numerics;
using Falko.Logging.Factories;
using Falko.Logging.Logs;
using JetBrains.Annotations;

namespace Falko.Logging.Loggers;

public readonly partial struct Logger
{
    #region Log()

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, DefaultInterpolatedStringHandler messageHandler)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, messageHandler.ToStringAndClear());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message);
        }
    }

    #endregion

    #region Log(Argument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>(T messageArgument, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error,
                messageArgument, messageFactory);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>(Exception? exception, T messageArgument, LogMessageFactory<T> messageFactory)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception,
                messageArgument, messageFactory);
        }
    }

    #endregion

    #region Log(short)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        short argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(ushort)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ushort argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(int)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)] [StructuredMessageTemplate] string? message,
        int argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(nint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(uint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        uint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(nuint)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        nuint argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(long)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        long argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(ulong)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        ulong argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(BigInteger)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        BigInteger argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(float)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        float argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(double)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        double argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(decimal)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        decimal argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(Guid)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        Guid argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(TimeSpan)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeSpan argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(TimeOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        TimeOnly argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(DateTime)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTime argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(DateTimeOffset)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateTimeOffset argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(DateOnly)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        DateOnly argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(byte)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        byte argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(sbyte)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        sbyte argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(char)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        char argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(string, string, string, string)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(string...)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params string?[] arguments)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(T, T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(T, T, T, T)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        T1 argument1,
        T2 argument2,
        T3 argument3,
        T4 argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion

    #region Log(object...)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error([Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                arguments);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        params object?[] arguments)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                arguments);
        }
    }

    #endregion

    #region Log(LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T> argument)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3);
        }
    }

    #endregion

    #region Log(LogMessageArgument, LogMessageArgument, LogMessageArgument, LogMessageArgument)

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3, T4>([Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Error<T1, T2, T3, T4>(Exception? exception, [Localizable(false)][StructuredMessageTemplate] string? message,
        LogMessageArgument<T1> argument1,
        LogMessageArgument<T2> argument2,
        LogMessageArgument<T3> argument3,
        LogMessageArgument<T4> argument4)
    {
        var loggerContext = Volatile.Read(ref _loggerRuntime.LoggerContext);

        if (loggerContext.IsErrorLevelEnabled)
        {
            Log(loggerContext, LogLevel.Error, exception, message,
                argument1,
                argument2,
                argument3,
                argument4);
        }
    }

    #endregion
}
