namespace CodeContracts.UnitTests;

public class Compare
{
    public Compare(IComparable value, IComparable max)
    {
        Value = value;
        Max = max;
    }

    public IComparable Value { get; }
    public IComparable Max { get; }
}