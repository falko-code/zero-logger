using System.Logging.Builders;
using System.Logging.Logs;
using Falko.ZeroLogger.Tests.Helpers;

namespace Falko.ZeroLogger.Tests.Builders;

[TestFixture]
public sealed class LoggerContextBuilderTests
{
    [Test]
    public void LoggerContextBuilder_ShouldSetLevel_WhenLevelProvided()
    {
        // Arrange
        var builder = new LoggerContextBuilder();

        // Act
        var result = builder.SetLevel(LogLevels.ErrorAndAbove);

        // Assert
        Assert.That(result, Is.SameAs(builder));
    }

    [Test]
    public void LoggerContextBuilder_ShouldAddTarget_WhenValidRendererAndTarget()
    {
        // Arrange
        var builder = new LoggerContextBuilder();
        var testTarget = new TestLoggerTarget();

        // Act
        var result = builder.AddTarget(TestLogContextRenderer.Instance, testTarget);

        // Assert
        Assert.That(result, Is.SameAs(builder));

        testTarget.Dispose();
    }

    [Test]
    public void LoggerContextBuilder_ShouldThrow_WhenRendererIsNull()
    {
        // Arrange
        var builder = new LoggerContextBuilder();
        var testTarget = new TestLoggerTarget();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.AddTarget(null!, testTarget));

        testTarget.Dispose();
    }

    [Test]
    public void LoggerContextBuilder_ShouldThrow_WhenTargetIsNull()
    {
        // Arrange
        var builder = new LoggerContextBuilder();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.AddTarget(TestLogContextRenderer.Instance, null!));
    }

    [Test]
    public void LoggerContextBuilder_ShouldSupportFluentInterface()
    {
        // Arrange
        var builder = new LoggerContextBuilder();
        var testTarget1 = new TestLoggerTarget();
        var testTarget2 = new TestLoggerTarget();

        // Act & Assert
        var result = builder
            .SetLevel(LogLevels.InfoAndAbove)
            .AddTarget(TestLogContextRenderer.Instance, testTarget1)
            .AddTarget(TestLogContextRenderer.Instance, testTarget2);

        Assert.That(result, Is.SameAs(builder));

        testTarget1.Dispose();
        testTarget2.Dispose();
    }
}