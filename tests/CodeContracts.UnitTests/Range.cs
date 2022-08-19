namespace CodeContracts.UnitTests;

public class Range
{
    public Range(IComparable value, IComparable min, IComparable max)
    {
        Value = value;
        Min = min;
        Max = max;
    }

    public IComparable Value { get; }
    public IComparable Min { get; }
    public IComparable Max { get; }
}