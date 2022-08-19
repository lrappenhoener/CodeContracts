namespace CodeContracts.UnitTests;

public class LongTests : ComparableTests<long>
{
    protected override IEnumerable<long> PositiveValues { get; } = new List<long>
    {
        0,
        1,
        long.MaxValue
    };

    protected override IEnumerable<long> NegativeValues { get; } = new List<long>
    {
        -1,
        long.MinValue
    };

    protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
    {
        new Range(0L, 0L, 1L),
        new Range(0L, -1L, 0L),
        new Range(-1L, -1L, 0L),
        new Range(-1L, -1L, 1L),
        new Range(long.MinValue, long.MinValue, 1L),
        new Range(long.MaxValue, long.MaxValue - 1L, long.MaxValue),
    };

    protected override IEnumerable<Range> RangesThatAreInvalid { get; } = new List<Range>
    {
        new Range(0L, 1L, long.MaxValue),
        new Range(0L, long.MinValue, -1L),
        new Range(long.MaxValue, long.MinValue, long.MaxValue - 1L),
        new Range(long.MinValue, long.MinValue + 1L, long.MaxValue),
    };
}