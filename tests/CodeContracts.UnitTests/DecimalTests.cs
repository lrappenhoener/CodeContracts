namespace CodeContracts.UnitTests;

public class DecimalTests : ComparableTests<Decimal>
{
    protected override Decimal Zero => 0m;
    protected override Decimal Positive => 1m;
    protected override Decimal Negative => -1m;
    protected override Decimal Max => Decimal.MaxValue;
    protected override Decimal Min => Decimal.MinValue;
}