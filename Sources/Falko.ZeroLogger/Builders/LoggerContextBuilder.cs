using System.Logging.Contexts;
using System.Logging.Logs;
using System.Logging.Renderers;
using System.Logging.Targets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Builders;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public ref struct LoggerContextBuilder()
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

        _targetPairs.Add(new KeyValuePair<ILogContextRenderer, LoggerTarget>(renderer, target));

        return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LoggerContext Build(CancellationToken cancellationToken)
    {
        scoped var targetPairsSpan = CollectionsMarshal.AsSpan(_targetPairs);
        var targetPairsCount = _targetPairs.Count;

        var targets = new LoggerTarget[targetPairsCount];
        scoped var targetsSpan = targets.AsSpan();

        var renderers = new LogContextRendererSpan[targetPairsCount];
        scoped var renderersSpan = renderers.AsSpan();

        var targetGroupStartIndex = 0;
        var targetGroupRendererIndex = 0;

        while (targetGroupStartIndex < targetPairsCount)
        {
            var targetPair = targetPairsSpan[targetGroupStartIndex];
            var targetGroupRenderer = targetPair.Key;
            var targetGroupRenderersCount = 1;

            var targetGroupInsertIndex = targetGroupStartIndex + 1;

            targetsSpan[targetGroupStartIndex] = targetPair.Value;

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

                targetsSpan[targetGroupInsertIndex] = targetPairTarget;

                ++targetGroupInsertIndex;
                ++targetGroupRenderersCount;
            }

            renderersSpan[targetGroupRendererIndex++] = new LogContextRendererSpan
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
