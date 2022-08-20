namespace CodeContracts.UnitTests;

public class DecimalTests : ComparableTests<decimal>
{
    protected override decimal Zero => 0m;
    protected override decimal Positive => 1m;
    protected override decimal Negative => -1m;
    protected override decimal Max => decimal.MaxValue;
    protected override decimal Min => decimal.MinValue;
}