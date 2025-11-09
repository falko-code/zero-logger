namespace Falko.Logging.Builders;

public delegate void ValueStringBuilderAction<in T>(ref ValueStringBuilder builder, T argument)
#if NET9_0_OR_GREATER
    where T : allows ref struct;
#else
    ;
#endif
