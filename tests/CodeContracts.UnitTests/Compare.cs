namespace CodeContracts.UnitTests;

public class Compare<T> where T : IComparable
{
    public Compare(T value, T max)
    {
        Value = value;
        Max = max;
    }

    public T Value { get; }
    public T Max { get; }
}