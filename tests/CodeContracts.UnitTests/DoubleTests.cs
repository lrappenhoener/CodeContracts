using FluentAssertions;

namespace CodeContracts.UnitTests;

public class DoubleTests : ComparableTests<double>
{
    protected override double Zero => 0.0d;
    protected override double Positive => 1.0d;
    protected override double Negative => -1.0d;
    protected override double Max => double.MaxValue;
    protected override double Min => double.MinValue;
}
