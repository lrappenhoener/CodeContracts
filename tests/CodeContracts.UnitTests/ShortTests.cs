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
}