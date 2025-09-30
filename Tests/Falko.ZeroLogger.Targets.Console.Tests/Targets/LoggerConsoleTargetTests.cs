using System.Logging.Builders;
using System.Logging.Concurrents;
using System.Logging.Contexts;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Renderers;
using System.Logging.Runtimes;
using System.Logging.Targets;

namespace Falko.ZeroLogger.Targets.Console.Tests.Targets;

[TestFixture]
public sealed class LoggerConsoleTargetTests
{
    private StringWriter _consoleWriter = null!;
    private TextWriter _originalConsoleOut = null!;

    [SetUp]
    public void SetUp()
    {
        _originalConsoleOut = System.Console.Out;
        _consoleWriter = new StringWriter();
        System.Console.SetOut(_consoleWriter);
    }

    [TearDown]
    public void TearDown()
    {
        System.Console.SetOut(_originalConsoleOut);
        _consoleWriter?.Dispose();
    }

    [Test]
    public void LoggerConsoleTarget_ShouldBeInstanceTarget()
    {
        // Act & Assert
        Assert.That(LoggerConsoleTarget.Instance, Is.Not.Null);
        
        // Test that getting instance multiple times returns the same object (singleton pattern)
        var instance1 = LoggerConsoleTarget.Instance;
        var instance2 = LoggerConsoleTarget.Instance;
        Assert.That(instance1, Is.SameAs(instance2));
    }

    [Test]
    public void LoggerConsoleTarget_ShouldNotRequireSynchronization()
    {
        // Act & Assert
        Assert.That(LoggerConsoleTarget.Instance.RequiresSynchronization, Is.True); // Console output should be synchronized
    }

    [Test]
    public void LoggerConsoleTarget_ShouldInitializeSuccessfully()
    {
        // Arrange
        var target = LoggerConsoleTarget.Instance;

        // Act & Assert
        Assert.DoesNotThrow(() => target.Initialize(CancellationContext.None));
        Assert.DoesNotThrow(() => target.Initialize());
    }

    [Test]
    public void LoggerConsoleTarget_ShouldDisposeSuccessfully()
    {
        // Arrange
        var target = LoggerConsoleTarget.Instance;

        // Act & Assert
        Assert.DoesNotThrow(() => target.Dispose(CancellationContext.None));
        Assert.DoesNotThrow(() => target.Dispose());
    }

    [Test]
    public void LoggerConsoleTarget_ShouldWriteToConsole_WhenPublishCalled()
    {
        // Arrange
        var target = LoggerConsoleTarget.Instance;
        var renderer = new TestRenderer();
        var context = new LogContext(
            "TestSource",
            LogLevel.Info,
            DateTimeOffset.Now,
            new TestMessageRenderer("Test message")
        );

        // Act
        target.Publish(context, renderer, CancellationToken.None);

        // Assert
        var output = _consoleWriter.ToString();
        Assert.That(output, Does.Contain("Test message"));
        Assert.That(output, Does.Contain("[Info]"));
        Assert.That(output, Does.Contain("TestSource"));
    }

    [Test]
    public void LoggerConsoleTarget_ShouldWriteMultipleMessages()
    {
        // Arrange
        var target = LoggerConsoleTarget.Instance;
        var renderer = new TestRenderer();

        // Act
        target.Publish(CreateTestContext("First message", LogLevel.Info), renderer, CancellationToken.None);
        target.Publish(CreateTestContext("Second message", LogLevel.Error), renderer, CancellationToken.None);

        // Assert
        var output = _consoleWriter.ToString();
        Assert.That(output, Does.Contain("First message"));
        Assert.That(output, Does.Contain("Second message"));
        Assert.That(output, Does.Contain("[Info]"));
        Assert.That(output, Does.Contain("[Error]"));
    }

    [Test]
    public void LoggerConsoleTarget_ShouldWorkWithRealLogger()
    {
        // Arrange
        var runtime = new LoggerRuntime();
        runtime.Initialize(builder => builder
            .AddTarget(new TestRenderer(), LoggerConsoleTarget.Instance)
            .SetLevel(LogLevels.InfoAndAbove));

        var logger = typeof(LoggerConsoleTargetTests).CreateLogger(runtime);

        // Act
        logger.Info("Integration test message");
        logger.Error("Error test message");

        // Assert
        var output = _consoleWriter.ToString();
        Assert.That(output, Does.Contain("Integration test message"));
        Assert.That(output, Does.Contain("Error test message"));
        Assert.That(output, Does.Contain("[Info]"));
        Assert.That(output, Does.Contain("[Error]"));

        // Cleanup
        runtime.Dispose();
    }

    [Test]
    public void LoggerConsoleTarget_ShouldHandleCancellation()
    {
        // Arrange
        var target = LoggerConsoleTarget.Instance;
        var renderer = new TestRenderer();
        var context = CreateTestContext("Test message", LogLevel.Info);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert - Should not throw even with cancelled token
        Assert.DoesNotThrow(() => target.Publish(context, renderer, cts.Token));
    }

    private static LogContext CreateTestContext(string message, LogLevel level)
    {
        return new LogContext(
            "TestSource",
            level,
            DateTimeOffset.Now,
            new TestMessageRenderer(message)
        );
    }

    private sealed class TestRenderer : ILogContextRenderer
    {
        public string Render(in LogContext logContext)
        {
            return $"[{logContext.Level}] {logContext.Source}: {logContext.Message.Render()}\n";
        }
    }

    private sealed class TestMessageRenderer : ILogMessageRenderer
    {
        private readonly string _message;

        public TestMessageRenderer(string message)
        {
            _message = message;
        }

        public string Render() => _message;
    }
}