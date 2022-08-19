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
}