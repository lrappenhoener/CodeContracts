namespace CodeContracts.UnitTests;

public class DecimalTests : ComparableTests<Decimal>
{
    protected override IEnumerable<Decimal> PositiveValues { get; } = new List<Decimal>
    {
        0m,
        1m,
        Decimal.MaxValue
    };

    protected override IEnumerable<Decimal> NegativeValues { get; } = new List<Decimal>
    {
        -1m,
        Decimal.MinValue
    };

    protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
    {
        new Range(0.01m, 0.001m, 1m),
        new Range(0m, -1m, 0m),
        new Range(-1m, -1m, 0m),
        new Range(-1m, -1m, 1m),
        new Range(Decimal.MinValue, Decimal.MinValue, 1m),
        new Range(Decimal.MaxValue, Decimal.MaxValue - 1m, Decimal.MaxValue),
    };

    protected override IEnumerable<Range> RangesThatAreInvalid { get; } = new List<Range>
    {
        new Range(0m, 0.0001m, Decimal.MaxValue),
        new Range(0m, Decimal.MinValue, -0.0001m),
    };
}