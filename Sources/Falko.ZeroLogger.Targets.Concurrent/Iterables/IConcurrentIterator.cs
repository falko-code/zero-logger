namespace System.Logging.Iterables;

internal interface IConcurrentIterator
{
    const int ItemIterationIncrement = 1;

    int Iterator { get; set; }

    int Iteration();

    void Iterate(int currentIterator);

    bool TryIterate(int currentIterator);

    void Exchange(int nextIterator);

    bool TryExchange(int currentIterator, int nextIterator);
}
