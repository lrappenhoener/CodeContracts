using FluentAssertions;

namespace CodeContracts.UnitTests;

public class DoubleTests : ComparableTests<double>
{
    protected override IEnumerable<double> PositiveValues { get; } = new List<double>
    {
        0.0,
        1.0,
        double.MaxValue
    };

    protected override IEnumerable<double> NegativeValues { get; } = new List<double>
    {
        -1.0,
        double.MinValue
    };
}