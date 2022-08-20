namespace CodeContracts.UnitTests;

public class FloatTests : ComparableTests<float>
{
    protected override float Zero => 0.0f;
    protected override float Positive => 1.0f;
    protected override float Negative => -1.0f;
    protected override float Max => float.MaxValue;
    protected override float Min => float.MinValue;
}