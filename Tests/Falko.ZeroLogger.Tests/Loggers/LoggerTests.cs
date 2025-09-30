using System.Logging.Builders;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Runtimes;
using Falko.ZeroLogger.Tests.Helpers;

namespace Falko.ZeroLogger.Tests.Loggers;

[TestFixture]
public sealed class LoggerTests
{
    private LoggerRuntime _loggerRuntime = null!;
    private TestLoggerTarget _testTarget = null!;

    [SetUp]
    public void SetUp()
    {
        _testTarget = new TestLoggerTarget();
        _loggerRuntime = new LoggerRuntime().Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, _testTarget)
            .SetLevel(LogLevels.TraceAndAbove));
    }

    [TearDown]
    public void TearDown()
    {
        _loggerRuntime?.Dispose();
        _testTarget?.Dispose();
    }

    #region Basic Logging Tests

    [Test]
    public void Logger_ShouldLogTrace_WhenTraceEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Trace("Test trace message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Trace]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test trace message"));
    }

    [Test]
    public void Logger_ShouldLogDebug_WhenDebugEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Debug("Test debug message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Debug]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test debug message"));
    }

    [Test]
    public void Logger_ShouldLogInfo_WhenInfoEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info("Test info message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Info]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test info message"));
    }

    [Test]
    public void Logger_ShouldLogWarn_WhenWarnEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Warn("Test warn message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Warn]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test warn message"));
    }

    [Test]
    public void Logger_ShouldLogError_WhenErrorEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Error("Test error message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Error]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test error message"));
    }

    [Test]
    public void Logger_ShouldLogFatal_WhenFatalEnabled()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Fatal("Test fatal message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Fatal]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Test fatal message"));
    }

    #endregion

    #region Log Level Filtering Tests

    [Test]
    public void Logger_ShouldNotLogTrace_WhenTraceDisabled()
    {
        // Arrange
        var runtime = new LoggerRuntime().Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, _testTarget)
            .SetLevel(LogLevels.DebugAndAbove));
        var logger = typeof(LoggerTests).CreateLogger(runtime);

        // Act
        logger.Trace("This should not be logged");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(0));

        runtime.Dispose();
    }

    [Test]
    public void Logger_ShouldNotLogDebug_WhenDebugDisabled()
    {
        // Arrange
        var runtime = new LoggerRuntime().Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, _testTarget)
            .SetLevel(LogLevels.InfoAndAbove));
        var logger = typeof(LoggerTests).CreateLogger(runtime);

        // Act
        logger.Debug("This should not be logged");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(0));

        runtime.Dispose();
    }

    #endregion

    #region Exception Logging Tests

    [Test]
    public void Logger_ShouldLogException_WhenExceptionProvided()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);
        var exception = new InvalidOperationException("Test exception");

        // Act
        logger.Error(exception, "Error occurred");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("[Error]"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Error occurred"));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Exception: Test exception"));
    }

    [Test]
    public void Logger_ShouldLogOnlyException_WhenMessageIsNull()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);
        var exception = new ArgumentException("Test argument exception");

        // Act
        logger.Error(exception, (string?)null);

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Exception: Test argument exception"));
    }

    #endregion

    #region Parameterized Logging Tests

    [Test]
    public void Logger_ShouldLogWithSingleParameter_WhenStringArgument()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info("User {0} logged in", "John");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("User John logged in"));
    }

    [Test]
    public void Logger_ShouldLogWithMultipleParameters_WhenStringArguments()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info("User {0} with ID {1} logged in", "Jane", "12345");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("User Jane with ID 12345 logged in"));
    }

    [Test]
    public void Logger_ShouldLogWithNumericParameters()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info("Processing {0} items at {1}ms", 100, 250);

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("Processing 100 items at 250ms"));
    }

    #endregion

    #region Null Message Handling

    [Test]
    public void Logger_ShouldNotLog_WhenMessageIsNull()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info((string?)null);

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(0));
    }

    [Test]
    public void Logger_ShouldNotLog_WhenMessageAndExceptionAreNull()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info((Exception?)null, (string?)null);

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(0));
    }

    #endregion

    #region Source Information Tests

    [Test]
    public void Logger_ShouldIncludeSourceInformation()
    {
        // Arrange
        var logger = typeof(LoggerTests).CreateLogger(_loggerRuntime);

        // Act
        logger.Info("Test message");

        // Assert
        Assert.That(_testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(_testTarget.LogMessages.First(), Does.Contain("LoggerTests"));
    }

    #endregion
}