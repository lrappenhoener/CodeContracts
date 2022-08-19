namespace CodeContracts.UnitTests;

public class LongTests : ComparableTests<long>
{
    protected override IEnumerable<long> PositiveValues { get; } = new List<long>
    {
        0,
        1,
        long.MaxValue
    };

    protected override IEnumerable<long> NegativeValues { get; } = new List<long>
    {
        -1,
        long.MinValue
    };
}