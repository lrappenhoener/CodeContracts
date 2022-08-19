namespace CodeContracts.UnitTests;

public class FloatTests : ComparableTests<float>
{
    protected override IEnumerable<float> PositiveValues { get; } = new List<float>
    {
        0.0f,
        1.0f,
        float.MaxValue
    };

    protected override IEnumerable<float> NegativeValues { get; } = new List<float>
    {
        -1.0f,
        float.MinValue
    };

    protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
    {
        new Range(0.0f, 0.0f, 1.0f),
        new Range(0.0f, -1.0f, 0.0f),
        new Range(-1.0f, -1.0f, 0.0f),
        new Range(-1.0f, -1.0f, 1.0f),
        new Range(float.MinValue, float.MinValue, 1.0f),
        new Range(float.MaxValue, float.MaxValue - 1.0f, float.MaxValue),
    };

    protected override IEnumerable<Range> RangesThatAreInvalid { get; } = new List<Range>
    {
        new Range(0f, 0.0001f, float.MaxValue),
        new Range(0f, float.MinValue, -0.0001f),
    };
}