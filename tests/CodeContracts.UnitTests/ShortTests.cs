namespace CodeContracts.UnitTests;

public class ShortTests : ComparableTests<short>
{
    protected override IEnumerable<short> PositiveValues { get; } = new List<short>
    {
        0,
        1,
        short.MaxValue
    };

    protected override IEnumerable<short> NegativeValues { get; } = new List<short>
    {
        -1,
        short.MinValue
    };

    protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
    {
        new Range((short)0, (short)0, (short)1),
        new Range((short)0, (short)-1, (short)0),
        new Range((short)-1, (short)-1, (short)0),
        new Range((short)-1, (short)-1, (short)1),
        new Range(short.MinValue, short.MinValue, (short)1),
        new Range(short.MaxValue, (short)(short.MaxValue - 1), short.MaxValue),
    };
}