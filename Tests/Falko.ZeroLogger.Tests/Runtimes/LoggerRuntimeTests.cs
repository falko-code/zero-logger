using System.Logging.Builders;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Runtimes;
using Falko.ZeroLogger.Tests.Helpers;

namespace Falko.ZeroLogger.Tests.Runtimes;

[TestFixture]
public sealed class LoggerRuntimeTests
{
    [Test]
    public void LoggerRuntime_ShouldInitialize_WhenValidConfiguration()
    {
        // Arrange
        var testTarget = new TestLoggerTarget();
        var runtime = new LoggerRuntime();

        // Act
        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget)
            .SetLevel(LogLevels.InfoAndAbove));

        // Assert
        Assert.That(testTarget.IsInitialized, Is.True);
        Assert.That(runtime.GetLoggerContext(), Is.Not.Null);

        // Cleanup
        runtime.Dispose();
        testTarget.Dispose();
    }

    [Test]
    public void LoggerRuntime_ShouldDispose_WhenDisposeIsCalled()
    {
        // Arrange
        var testTarget = new TestLoggerTarget();
        var runtime = new LoggerRuntime();
        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget)
            .SetLevel(LogLevels.InfoAndAbove));

        // Act
        runtime.Dispose();

        // Assert
        Assert.That(testTarget.IsDisposed, Is.True);

        testTarget.Dispose();
    }

    [Test]
    public void LoggerRuntime_ShouldReinitialize_WhenInitializeCalledMultipleTimes()
    {
        // Arrange
        var testTarget1 = new TestLoggerTarget();
        var testTarget2 = new TestLoggerTarget();
        var runtime = new LoggerRuntime();

        // Act & Assert - First initialization
        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget1)
            .SetLevel(LogLevels.InfoAndAbove));

        Assert.That(testTarget1.IsInitialized, Is.True);
        Assert.That(testTarget1.IsDisposed, Is.False);

        // Act & Assert - Second initialization (should dispose first target)
        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget2)
            .SetLevel(LogLevels.DebugAndAbove));

        Assert.That(testTarget1.IsDisposed, Is.True);
        Assert.That(testTarget2.IsInitialized, Is.True);

        // Cleanup
        runtime.Dispose();
        testTarget1.Dispose();
        testTarget2.Dispose();
    }

    [Test]
    public void LoggerRuntime_ShouldCreateLoggers_WithCorrectConfiguration()
    {
        // Arrange
        var testTarget = new TestLoggerTarget();
        var runtime = new LoggerRuntime();
        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget)
            .SetLevel(LogLevels.InfoAndAbove));

        // Act
        var logger = typeof(LoggerRuntimeTests).CreateLogger(runtime);
        logger.Info("Test message");

        // Assert
        Assert.That(testTarget.LogMessages, Has.Count.EqualTo(1));
        Assert.That(testTarget.LogMessages.First(), Does.Contain("[Info]"));
        Assert.That(testTarget.LogMessages.First(), Does.Contain("Test message"));

        // Cleanup
        runtime.Dispose();
        testTarget.Dispose();
    }

    [Test]
    public void LoggerRuntime_ShouldSupportMultipleTargets()
    {
        // Arrange
        var testTarget1 = new TestLoggerTarget();
        var testTarget2 = new TestLoggerTarget();
        var runtime = new LoggerRuntime();

        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, testTarget1)
            .AddTarget(TestLogContextRenderer.Instance, testTarget2)
            .SetLevel(LogLevels.InfoAndAbove));

        // Act
        var logger = typeof(LoggerRuntimeTests).CreateLogger(runtime);
        logger.Info("Test message to both targets");

        // Assert
        Assert.That(testTarget1.LogMessages, Has.Count.EqualTo(1));
        Assert.That(testTarget2.LogMessages, Has.Count.EqualTo(1));
        Assert.That(testTarget1.LogMessages.First(), Does.Contain("Test message to both targets"));
        Assert.That(testTarget2.LogMessages.First(), Does.Contain("Test message to both targets"));

        // Cleanup
        runtime.Dispose();
        testTarget1.Dispose();
        testTarget2.Dispose();
    }

    [Test]
    public void LoggerRuntime_ShouldHandleEmptyConfiguration()
    {
        // Arrange
        var runtime = new LoggerRuntime();

        // Act
        runtime.Initialize(builder => builder.SetLevel(LogLevels.InfoAndAbove));

        // Assert - Should not throw and should create context
        Assert.That(runtime.GetLoggerContext(), Is.Not.Null);

        // Act - Logging should not throw even with no targets
        var logger = typeof(LoggerRuntimeTests).CreateLogger(runtime);
        Assert.DoesNotThrow(() => logger.Info("Test message"));

        // Cleanup
        runtime.Dispose();
    }

    [Test]
    public void LoggerRuntime_Global_ShouldBeAvailable()
    {
        // Act & Assert
        Assert.That(LoggerRuntime.Global, Is.Not.Null);
        Assert.That(LoggerRuntime.Global.GetLoggerContext(), Is.Not.Null);
    }

    [Test]
    public void LoggerRuntime_ShouldHandlePublishingGracefully_WhenTargetThrows()
    {
        // Arrange - Test publishing instead of disposal since disposal error doesn't get caught
        var faultyTarget = new FaultyPublishTarget();
        var runtime = new LoggerRuntime();

        runtime.Initialize(builder => builder
            .AddTarget(TestLogContextRenderer.Instance, faultyTarget)
            .SetLevel(LogLevels.InfoAndAbove));

        var logger = typeof(LoggerRuntimeTests).CreateLogger(runtime);

        // Act & Assert - Should not throw during publish, error should be caught internally
        Assert.DoesNotThrow(() => logger.Info("Test message"));

        // Cleanup
        runtime.Dispose();
        faultyTarget.Dispose();
    }

    private sealed class FaultyPublishTarget : TestLoggerTarget
    {
        public override void Publish(in System.Logging.Contexts.LogContext context, System.Logging.Renderers.ILogContextRenderer renderer, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException("Simulated publish error");
        }
    }
}