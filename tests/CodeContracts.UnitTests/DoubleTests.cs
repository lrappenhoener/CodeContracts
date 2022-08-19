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
    
    protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
    {
        new Range(0.0, 0.0, 1.0),
        new Range(0.0, -1.0, 0.0),
        new Range(-1.0, -1.0, 0.0),
        new Range(-1.0, -1.0, 1.0),
        new Range(double.MinValue, double.MinValue, 1.0),
        new Range(double.MaxValue, double.MaxValue - 1.0, double.MaxValue),
    };
}