namespace System.Logging.Factories;

public delegate string? LogMessageFactory();

public delegate string? LogMessageFactory<in T>(T state);
