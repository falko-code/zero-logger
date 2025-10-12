using System.Runtime.InteropServices;
using Falko.Logging.Contexts;
using Falko.Logging.Logs;
using Falko.Logging.Renderers;
using Falko.Logging.Targets;

namespace Falko.Logging.Builders;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public sealed class LoggerContextBuilder()
{
    private readonly List<KeyValuePair<ILogContextRenderer, LoggerTarget>> _targetPairs = [];

    private LogLevel _level = LogLevels.TraceAndAbove;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LoggerContextBuilder SetLevel(LogLevel level)
    {
        _level = level;
        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LoggerContextBuilder AddTarget(ILogContextRenderer renderer, LoggerTarget target)
    {
        ArgumentNullException.ThrowIfNull(renderer, nameof(renderer));
        ArgumentNullException.ThrowIfNull(target, nameof(target));

        if (target.RequiresSynchronization) target = new LockingLoggerTarget(target);

        _targetPairs.Add(new KeyValuePair<ILogContextRenderer, LoggerTarget>(renderer, target));

        return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LoggerContext Build(CancellationToken cancellationToken)
    {
        var targetPairsCount = _targetPairs.Count;

        if (targetPairsCount is 0) return LoggerContext.Empty;

        scoped var targetPairsSpan = CollectionsMarshal.AsSpan(_targetPairs);

        var targets = new LoggerTarget[targetPairsCount];
        scoped ref var targetsReference = ref MemoryMarshal.GetArrayDataReference(targets);

        var renderers = new LogContextRendererSpan[targetPairsCount];
        scoped ref var renderersReference = ref MemoryMarshal.GetArrayDataReference(renderers);

        var targetGroupStartIndex = 0;
        var targetGroupRendererIndex = 0;

        while (targetGroupStartIndex < targetPairsCount)
        {
            var targetPair = targetPairsSpan[targetGroupStartIndex];
            var targetGroupRenderer = targetPair.Key;
            var targetGroupRenderersCount = 1;

            var targetGroupInsertIndex = targetGroupStartIndex + 1;

            Unsafe.Add(ref targetsReference, targetGroupStartIndex) = targetPair.Value;

            for (var targetPairIndex = targetGroupInsertIndex; targetPairIndex < targetPairsCount; targetPairIndex++)
            {
                targetPair = targetPairsSpan[targetPairIndex];

                var targetPairRenderer = targetPair.Key;
                var targetPairTarget = targetPair.Value;

                if (ReferenceEquals(targetPairRenderer, targetGroupRenderer) is false) continue;

                if (targetPairIndex != targetGroupInsertIndex)
                {
                    targetPairsSpan[targetPairIndex] = targetPairsSpan[targetGroupInsertIndex];
                    targetPairsSpan[targetGroupInsertIndex] = targetPair;
                }

                Unsafe.Add(ref targetsReference, targetGroupInsertIndex) = targetPairTarget;

                ++targetGroupInsertIndex;
                ++targetGroupRenderersCount;
            }

            Unsafe.Add(ref renderersReference, targetGroupRendererIndex++) = new LogContextRendererSpan
            (
                renderer: targetGroupRenderer,
                count: targetGroupRenderersCount
            );

            targetGroupStartIndex = targetGroupInsertIndex;
        }

        Array.Resize(ref renderers, targetGroupRendererIndex);

        return new LoggerContext(_level, targets, renderers, cancellationToken);
    }
}
