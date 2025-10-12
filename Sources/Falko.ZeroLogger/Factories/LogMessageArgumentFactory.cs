namespace Falko.Logging.Factories;

public delegate string? LogMessageArgumentFactory();

public delegate string? LogMessageArgumentFactory<in T>(T argument);
