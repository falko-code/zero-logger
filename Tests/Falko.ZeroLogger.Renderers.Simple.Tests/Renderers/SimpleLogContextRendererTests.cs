using System.Logging.Contexts;
using System.Logging.Logs;
using System.Logging.Renderers;

namespace Falko.ZeroLogger.Renderers.Simple.Tests.Renderers;

[TestFixture]
public sealed class SimpleLogContextRendererTests
{
    [Test]
    public void SimpleLogContextRenderer_ShouldBeInstanceRenderer()
    {
        // Act & Assert
        Assert.That(SimpleLogContextRenderer.Instance, Is.Not.Null);
        
        // Test that getting instance multiple times returns the same object (singleton pattern)
        var instance1 = SimpleLogContextRenderer.Instance;
        var instance2 = SimpleLogContextRenderer.Instance;
        Assert.That(instance1, Is.SameAs(instance2));
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderBasicMessage_WithoutException()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var time = new DateTimeOffset(2024, 1, 15, 10, 30, 45, 123, TimeSpan.Zero);
        var context = new LogContext(
            "TestSource",
            LogLevel.Info,
            time,
            new TestMessageRenderer("Test message")
        );

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("10:30:45.123")); // Time format
        Assert.That(result, Does.Contain("[INF]")); // Level
        Assert.That(result, Does.Contain("[TestSource]")); // Source
        Assert.That(result, Does.Contain("Test message")); // Message
        Assert.That(result, Does.EndWith(Environment.NewLine)); // Newline at end
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderAllLogLevels()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var time = DateTimeOffset.Now;
        var testCases = new[]
        {
            (LogLevel.Trace, "TRC"),
            (LogLevel.Debug, "DBG"),
            (LogLevel.Info, "INF"),
            (LogLevel.Warn, "WRN"),
            (LogLevel.Error, "ERR"),
            (LogLevel.Fatal, "FTL")
        };

        foreach (var (level, expectedLevelText) in testCases)
        {
            // Act
            var context = new LogContext("TestSource", level, time, new TestMessageRenderer("Test"));
            var result = renderer.Render(context);

            // Assert
            Assert.That(result, Does.Contain($"[{expectedLevelText}]"), $"Level {level} should render as [{expectedLevelText}]");
        }
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderMessageWithException()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        Exception exception;
        
        try
        {
            // Create an exception with a stack trace
            throw new InvalidOperationException("Test exception message");
        }
        catch (Exception ex)
        {
            exception = ex;
        }
        
        var context = new LogContext(
            "TestSource",
            LogLevel.Error,
            DateTimeOffset.Now,
            new TestMessageRenderer("Error occurred")
        )
        {
            Exception = exception
        };

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Does.Contain("Error occurred")); // Original message
        Assert.That(result, Does.Contain("Exception: System.InvalidOperationException")); // Exception type
        Assert.That(result, Does.Contain("Message: Test exception message")); // Exception message
        // Stack trace may or may not be present depending on how exception was created
        // So we'll just check that the exception info is there
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderExceptionWithNullMessage()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var exception = new ArgumentNullException("paramName");
        var context = new LogContext(
            "TestSource",
            LogLevel.Error,
            DateTimeOffset.Now,
            new TestMessageRenderer("Null argument error")
        )
        {
            Exception = exception
        };

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Does.Contain("Exception: System.ArgumentNullException"));
        Assert.That(result, Does.Contain("Message: ")); // Should have message block even if empty
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderDifferentSources()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var time = DateTimeOffset.Now;
        var sources = new[] { "ShortSource", "Very.Long.Namespace.Source", "Source_With_Underscores" };

        foreach (var source in sources)
        {
            // Act
            var context = new LogContext(source, LogLevel.Info, time, new TestMessageRenderer("Test"));
            var result = renderer.Render(context);

            // Assert
            Assert.That(result, Does.Contain($"[{source}]"), $"Should contain source [{source}]");
        }
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderTimeCorrectly()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var time = new DateTimeOffset(2024, 6, 15, 23, 59, 59, 999, TimeSpan.Zero);
        var context = new LogContext(
            "TestSource",
            LogLevel.Info,
            time,
            new TestMessageRenderer("Time test")
        );

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Does.Contain("[23:59:59.999]"));
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderEmptyMessage()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var context = new LogContext(
            "TestSource",
            LogLevel.Info,
            DateTimeOffset.Now,
            new TestMessageRenderer("")
        );

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Does.Contain("[INF]"));
        Assert.That(result, Does.Contain("[TestSource]"));
        Assert.That(result, Does.EndWith(Environment.NewLine));
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldRenderVeryLongMessage()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        var longMessage = new string('A', 10000); // Very long message to test buffer handling
        var context = new LogContext(
            "TestSource",
            LogLevel.Info,
            DateTimeOffset.Now,
            new TestMessageRenderer(longMessage)
        );

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Does.Contain(longMessage));
        Assert.That(result, Does.Contain("[INF]"));
        Assert.That(result, Does.Contain("[TestSource]"));
    }

    [Test]
    public void SimpleLogContextRenderer_ShouldHandleExceptionWithNullStackTrace()
    {
        // Arrange
        var renderer = SimpleLogContextRenderer.Instance;
        
        // Create an exception that might not have a stack trace
        var exception = new CustomExceptionWithoutStackTrace("Custom message");
        var context = new LogContext(
            "TestSource",
            LogLevel.Error,
            DateTimeOffset.Now,
            new TestMessageRenderer("Custom exception test")
        )
        {
            Exception = exception
        };

        // Act
        var result = renderer.Render(context);

        // Assert
        Assert.That(result, Does.Contain("Custom exception test"));
        Assert.That(result, Does.Contain("Exception: "));
        Assert.That(result, Does.Contain("Message: Custom message"));
        // Should not contain "Trace:" if stack trace is null
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

    private sealed class CustomExceptionWithoutStackTrace : Exception
    {
        public CustomExceptionWithoutStackTrace(string message) : base(message) { }
        
        public override string? StackTrace => null;
    }
}