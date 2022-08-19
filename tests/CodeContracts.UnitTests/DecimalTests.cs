namespace CodeContracts.UnitTests;

public class DecimalTests : ComparableTests<Decimal>
{
    protected override IEnumerable<Decimal> PositiveValues { get; } = new List<Decimal>
    {
        0,
        1,
        Decimal.MaxValue
    };

    protected override IEnumerable<Decimal> NegativeValues { get; } = new List<Decimal>
    {
        -1,
        Decimal.MinValue
    };
}