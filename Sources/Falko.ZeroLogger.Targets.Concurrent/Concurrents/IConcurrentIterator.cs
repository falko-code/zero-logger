namespace System.Logging.Concurrents;

internal interface IConcurrentIterator
{
    const int ItemIterationIncrement = 1;

    int Iteration();

    void Iterate(int currentIterator);

    bool TryIterate(int currentIterator);

    void Exchange(int nextIterator);

    bool TryExchange(int currentIterator, int nextIterator);
}
