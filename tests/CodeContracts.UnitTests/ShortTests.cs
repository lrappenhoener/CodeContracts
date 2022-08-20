namespace CodeContracts.UnitTests;

public class ShortTests : ComparableTests<short>
{
    protected override short Zero => 0;
    protected override short Positive => 1;
    protected override short Negative => -1;
    protected override short Max => short.MaxValue;
    protected override short Min => short.MinValue;
}