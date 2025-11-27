namespace Falko.Logging.Builders;

public delegate void ValueStringStreamAction<T>(scoped ref ValueStringStream stream, in T state)
#if NET9_0_OR_GREATER
    where T : allows ref struct;
#else
    ;
#endif
