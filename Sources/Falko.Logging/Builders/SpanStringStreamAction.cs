namespace Falko.Logging.Builders;

public delegate void SpanStringStreamAction<T>(scoped ref SpanStringStream stream, in T state)
#if NET9_0_OR_GREATER
    where T : allows ref struct;
#else
    ;
#endif
