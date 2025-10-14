namespace Falko.Examples.Configurations;

public abstract class LoggerConfigurer
{
    public void Configure()
    {
        ConfigureZeroLogger();
        ConfigureNLogLogger();
    }

    protected abstract void ConfigureZeroLogger();

    protected abstract void ConfigureNLogLogger();
}
