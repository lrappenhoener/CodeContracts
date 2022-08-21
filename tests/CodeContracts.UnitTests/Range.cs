namespace CodeContracts.UnitTests;

public class Range<T> where T : IComparable
{
    public Range(T value, T min, T max)
    {
        Value = value;
        Min = min;
        Max = max;
    }

    public T Value { get; }
    public T Min { get; }
    public T Max { get; }
}