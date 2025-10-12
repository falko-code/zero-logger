namespace Falko.Logging.Concurrents;

internal interface IConcurrentIterator
{
    int Iteration();

    void Iterate(int currentIterator);

    bool TryIterate(int currentIterator);

    void Exchange(int nextIterator);

    bool TryExchange(int currentIterator, int nextIterator);
}
