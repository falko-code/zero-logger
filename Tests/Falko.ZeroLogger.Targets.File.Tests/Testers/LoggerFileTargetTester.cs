using Falko.Logging.Factories;
using Falko.Logging.Logs;
using Falko.Logging.Runtimes;
using Falko.Logging.Targets;
using Falko.ZeroLogger.Targets.File.Tests.Renderers;

namespace Falko.ZeroLogger.Targets.File.Tests.Testers;

public sealed class LoggerFileTargetTester
{
    [Test]
    public void LogFile_ShouldContainAllMessages_From1To10000()
    {
        // Arrange
        var logsDirectory = new DirectoryInfo("./Logs");
        DeleteDirectoryIfExists(logsDirectory);

        const string logsPrefix = "test";
        const int messageCount = 10000;

        var loggerRuntime = new LoggerRuntime().Initialize(builder => builder
            .AddTarget(OnlyMessageLogContextRenderer.Instance, new LoggerFileTarget(logsPrefix, logsDirectory.Name))
            .SetLevel(LogLevels.InfoAndAbove));

        var logger = typeof(LoggerFileTargetTester).CreateLogger(loggerRuntime);

        // Act
        Parallel.For(0, messageCount, i => logger.Info((i + 1).ToString()));

        loggerRuntime.Dispose();

        // Assert
        var logFile = Directory.EnumerateFiles(logsDirectory.FullName, $"{logsPrefix}*.log").FirstOrDefault();
        Assert.That(logFile, Is.Not.Null, "Log file should be created");

        var logFileInfo = new FileInfo(logFile!);
        Assert.That(logFileInfo.Length, Is.GreaterThan(0), "Log file should not be empty");

        var logLines = System.IO.File.ReadLines(logFile!);
        var foundNumbers = ExtractNumbersFromLines(logLines);

        AssertAllMessagesPresent(foundNumbers, messageCount);
    }

    private static void DeleteDirectoryIfExists(DirectoryInfo directory)
    {
        if (directory.Exists) directory.Delete(true);
    }

    private static HashSet<int> ExtractNumbersFromLines(IEnumerable<string> lines)
    {
        return lines
            .Select(line => int.TryParse(line, out var number) ? number : (int?)null)
            .Where(n => n.HasValue)
            .Select(n => n!.Value)
            .ToHashSet();
    }

    private static void AssertAllMessagesPresent(HashSet<int> foundNumbers, int messageCount)
    {
        for (var i = 1; i <= messageCount; i++)
        {
            Assert.That(foundNumbers, Does.Contain(i), $"Log file should contain the message '{i}'");
        }
    }
}
