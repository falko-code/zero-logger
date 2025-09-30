using System.Logging.Builders;
using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Renderers;
using System.Logging.Runtimes;
using System.Logging.Targets;

namespace Falko.ZeroLogger.Integration.Tests;

[TestFixture]
public sealed class EndToEndIntegrationTests
{
    private string _testDirectory = null!;

    [SetUp]
    public void SetUp()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"ZeroLoggerTests_{Guid.NewGuid()}");
        Directory.CreateDirectory(_testDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }

    [Test]
    public void EndToEnd_ShouldLogToMultipleTargets_WithDifferentRenderers()
    {
        // Arrange
        var logFile = Path.Combine(_testDirectory, "integration-test.log");
        var consoleWriter = new StringWriter();
        var originalConsoleOut = Console.Out;
        Console.SetOut(consoleWriter);

        try
        {
            var runtime = new LoggerRuntime();
            runtime.Initialize(builder => builder
                .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
                .AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("integration", _testDirectory))
                .SetLevel(LogLevels.DebugAndAbove));

            var logger = typeof(EndToEndIntegrationTests).CreateLogger(runtime);

            // Act
            logger.Debug("Debug message for testing");
            logger.Info("Information message with data: {0}", 42);
            logger.Warn("Warning message");
            logger.Error(new InvalidOperationException("Test error"), "Error occurred during processing");
            logger.Fatal("Fatal error - system shutting down");

            runtime.Dispose();

            // Assert - Console output
            var consoleOutput = consoleWriter.ToString();
            Assert.That(consoleOutput, Does.Contain("Debug message for testing"));
            Assert.That(consoleOutput, Does.Contain("Information message with data: 42"));
            Assert.That(consoleOutput, Does.Contain("Warning message"));
            Assert.That(consoleOutput, Does.Contain("Error occurred during processing"));
            Assert.That(consoleOutput, Does.Contain("Fatal error - system shutting down"));
            Assert.That(consoleOutput, Does.Contain("[DBG]"));
            Assert.That(consoleOutput, Does.Contain("[INF]"));
            Assert.That(consoleOutput, Does.Contain("[WRN]"));
            Assert.That(consoleOutput, Does.Contain("[ERR]"));
            Assert.That(consoleOutput, Does.Contain("[FTL]"));

            // Assert - File output
            var logFiles = Directory.GetFiles(_testDirectory, "integration*.log");
            Assert.That(logFiles, Has.Length.EqualTo(1));

            var fileContent = File.ReadAllText(logFiles[0]);
            Assert.That(fileContent, Does.Contain("Debug message for testing"));
            Assert.That(fileContent, Does.Contain("Information message with data: 42"));
            Assert.That(fileContent, Does.Contain("Warning message"));
            Assert.That(fileContent, Does.Contain("Error occurred during processing"));
            Assert.That(fileContent, Does.Contain("Fatal error - system shutting down"));
            Assert.That(fileContent, Does.Contain("Exception: System.InvalidOperationException"));
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
            consoleWriter.Dispose();
        }
    }

    [Test]
    public void EndToEnd_ShouldRespectLogLevels()
    {
        // Arrange
        var consoleWriter = new StringWriter();
        var originalConsoleOut = Console.Out;
        Console.SetOut(consoleWriter);

        try
        {
            var runtime = new LoggerRuntime();
            runtime.Initialize(builder => builder
                .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
                .SetLevel(LogLevels.WarnAndAbove)); // Only Warn, Error, Fatal

            var logger = typeof(EndToEndIntegrationTests).CreateLogger(runtime);

            // Act
            logger.Trace("Trace message - should not appear");
            logger.Debug("Debug message - should not appear");
            logger.Info("Info message - should not appear");
            logger.Warn("Warning message - should appear");
            logger.Error("Error message - should appear");
            logger.Fatal("Fatal message - should appear");

            runtime.Dispose();

            // Assert
            var consoleOutput = consoleWriter.ToString();
            Assert.That(consoleOutput, Does.Not.Contain("Trace message"));
            Assert.That(consoleOutput, Does.Not.Contain("Debug message"));
            Assert.That(consoleOutput, Does.Not.Contain("Info message"));
            Assert.That(consoleOutput, Does.Contain("Warning message - should appear"));
            Assert.That(consoleOutput, Does.Contain("Error message - should appear"));
            Assert.That(consoleOutput, Does.Contain("Fatal message - should appear"));
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
            consoleWriter.Dispose();
        }
    }

    [Test]
    public void EndToEnd_ShouldHandleHighThroughput()
    {
        // Arrange
        var runtime = new LoggerRuntime();
        runtime.Initialize(builder => builder
            .AddTarget(SimpleLogContextRenderer.Instance, new LoggerFileTarget("throughput", _testDirectory))
            .SetLevel(LogLevels.InfoAndAbove));

        var logger = typeof(EndToEndIntegrationTests).CreateLogger(runtime);
        const int messageCount = 1000;

        // Act
        var tasks = new Task[Environment.ProcessorCount];
        for (int t = 0; t < tasks.Length; t++)
        {
            int taskId = t;
            tasks[t] = Task.Run(() =>
            {
                for (int i = 0; i < messageCount / tasks.Length; i++)
                {
                    logger.Info("Message from task {0}, iteration {1}", taskId, i);
                }
            });
        }

        Task.WaitAll(tasks);
        runtime.Dispose();

        // Assert
        var logFiles = Directory.GetFiles(_testDirectory, "throughput*.log");
        Assert.That(logFiles, Has.Length.EqualTo(1));

        var fileContent = File.ReadAllText(logFiles[0]);
        var lines = fileContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        // Should have received most messages (allowing for some potential loss in high concurrency)
        Assert.That(lines.Length, Is.GreaterThan(messageCount * 0.9));
    }

    [Test]
    public void EndToEnd_ShouldWorkWithGlobalRuntime()
    {
        // Arrange
        var consoleWriter = new StringWriter();
        var originalConsoleOut = Console.Out;
        Console.SetOut(consoleWriter);

        try
        {
            // Use the global runtime
            LoggerRuntime.Global.Initialize(builder => builder
                .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
                .SetLevel(LogLevels.InfoAndAbove));

            var logger = typeof(EndToEndIntegrationTests).CreateLogger(LoggerRuntime.Global);

            // Act
            logger.Info("Global runtime test message");

            // Assert
            var consoleOutput = consoleWriter.ToString();
            Assert.That(consoleOutput, Does.Contain("Global runtime test message"));
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
            consoleWriter.Dispose();
        }
    }

    [Test]
    public void EndToEnd_ShouldHandleComplexMessages()
    {
        // Arrange
        var consoleWriter = new StringWriter();
        var originalConsoleOut = Console.Out;
        Console.SetOut(consoleWriter);

        try
        {
            var runtime = new LoggerRuntime();
            runtime.Initialize(builder => builder
                .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
                .SetLevel(LogLevels.InfoAndAbove));

            var logger = typeof(EndToEndIntegrationTests).CreateLogger(runtime);

            // Act - Test different parameter types
            logger.Info("String: {0}, Number: {1}, Date: {2}", "test", 123, DateTime.Now);
            logger.Info("Boolean: {0}, Guid: {1}", true, Guid.NewGuid());
            logger.Info("Object: {0}", new { Name = "Test", Value = 42 });

            runtime.Dispose();

            // Assert
            var consoleOutput = consoleWriter.ToString();
            Assert.That(consoleOutput, Does.Contain("String: test"));
            Assert.That(consoleOutput, Does.Contain("Number: 123"));
            Assert.That(consoleOutput, Does.Contain("Boolean: True"));
            Assert.That(consoleOutput, Does.Contain("Object:"));
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
            consoleWriter.Dispose();
        }
    }

    [Test]
    public void EndToEnd_ShouldHandleNestedExceptions()
    {
        // Arrange
        var consoleWriter = new StringWriter();
        var originalConsoleOut = Console.Out;
        Console.SetOut(consoleWriter);

        try
        {
            var runtime = new LoggerRuntime();
            runtime.Initialize(builder => builder
                .AddTarget(SimpleLogContextRenderer.Instance, LoggerConsoleTarget.Instance)
                .SetLevel(LogLevels.ErrorAndAbove));

            var logger = typeof(EndToEndIntegrationTests).CreateLogger(runtime);

            // Create nested exception
            Exception nestedException;
            try
            {
                try
                {
                    throw new ArgumentException("Inner exception message");
                }
                catch (Exception inner)
                {
                    throw new InvalidOperationException("Outer exception message", inner);
                }
            }
            catch (Exception ex)
            {
                nestedException = ex;
            }

            // Act
            logger.Error(nestedException, "Error with nested exception occurred");

            runtime.Dispose();

            // Assert
            var consoleOutput = consoleWriter.ToString();
            Assert.That(consoleOutput, Does.Contain("Error with nested exception occurred"));
            Assert.That(consoleOutput, Does.Contain("Exception: System.InvalidOperationException"));
            Assert.That(consoleOutput, Does.Contain("Message: Outer exception message"));
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
            consoleWriter.Dispose();
        }
    }
}