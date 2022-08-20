namespace CodeContracts.UnitTests;

public class LongTests : ComparableTests<long>
{
    protected override long Zero => 0L;
    protected override long Positive => 1L;
    protected override long Negative => -1L;
    protected override long Max => long.MaxValue;
    protected override long Min => long.MinValue;
}