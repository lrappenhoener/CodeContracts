using FluentAssertions;

namespace CodeContracts.UnitTests;

public abstract class ComparableTests<T> where T : IComparable
{
    protected abstract T Zero { get; }
    protected abstract T Positive { get; }
    protected abstract T Negative { get; }
    protected abstract T Max { get; }
    protected abstract T Min { get; }
    
    protected IEnumerable<T> PositiveValues { get; }
    protected IEnumerable<T> NegativeValues { get; } 
    protected IEnumerable<Range> RangesThatAreValid { get; } 
    protected IEnumerable<Range> RangesThatAreInvalid { get; } 
    protected IEnumerable<Compare> LesserValuesThatAreValid { get; } 
    protected IEnumerable<Compare> LesserValuesThatAreInvalid { get; } 

    protected ComparableTests()
    {
        PositiveValues = new List<T>
        {
            Zero,
            Positive,
            Max
        };
        
        NegativeValues = new List<T>
        {
            Negative,
            Min
        };

        RangesThatAreValid = new List<Range>
        {
            new Range(Zero, Negative, Positive),
            new Range(Zero, Min, Max),
            new Range(Positive, Negative, Positive),
            new Range(Negative, Negative, Positive),
            new Range(Negative, Min, Positive),
        };

        RangesThatAreInvalid = new List<Range>
        {
            new Range(Zero, Positive, Max),
            new Range(Zero, Min, Negative),
        };

        LesserValuesThatAreValid = new List<Compare>
        {
            new Compare(Zero, Positive),
            new Compare(Negative, Zero),
            new Compare(Positive, Max),
        };

        LesserValuesThatAreInvalid = new List<Compare>
        {
            new Compare(Positive, Zero),
            new Compare(Zero, Negative),
            new Compare(Max, Positive),
        };
    }

    [Fact]
    public void Positive_Requirement_Successful_Asserts_Positive_Values()
    {
        foreach (var positiveValue in PositiveValues)
        {
            var exception = Record.Exception(() =>
                Contract.For(positiveValue).Positive().Ok());

            exception.Should().BeNull();
        }
    }

    [Fact]
    public void Positive_Requirement_Successful_Asserts_Negative_Values()
    {
        foreach (var positiveValue in PositiveValues)
        {
            var exception = Record.Exception(() =>
                Contract.For(positiveValue).Positive().Ok());

            exception.Should().BeNull();
        }
    }

    [Fact]
    public void Negative_Requirement_Successful_Asserts_Negative_Values()
    {
        foreach (var negativeValue in NegativeValues)
        {
            var exception = Record.Exception(() =>
                Contract.For(negativeValue).Negative().Ok());

            exception.Should().BeNull();
        }
    }

    [Fact]
    public void Negative_Requirement_Successful_Asserts_Positive_Values()
    {
        foreach (var negativeValue in NegativeValues)
        {
            var exception = Record.Exception(() =>
                Contract.For(negativeValue).Negative().Ok());

            exception.Should().BeNull();
        }
    }

    [Fact]
    public void InRange_Requirement_Successful_Asserts_ValidRanges()
    {
        foreach (var range in RangesThatAreValid)
        {
            var exception = Record.Exception(() => Contract.For(range.Value).InRange(range.Min, range.Max).Ok());
            exception.Should().BeNull();
        }
    }

    [Fact]
    public void InRange_Requirement_Successful_Asserts_InvalidRanges()
    {
        foreach (var range in RangesThatAreInvalid)
        {
            var exception = Record.Exception(() => Contract.For(range.Value).InRange(range.Min, range.Max).Ok());
            exception.Should().NotBeNull();
        }
    }

    [Fact]
    public void Lesser_Requirement_Successful_Asserts_ValidValues()
    {
        foreach (var lesser in LesserValuesThatAreValid)
        {
            var exception = Record.Exception(() => Contract.For(lesser.Value).Lesser(lesser.Max).Ok());
            exception.Should().BeNull();
        }
    }

    [Fact]
    public void Lesser_Requirement_Successful_Asserts_InvalidValues()
    {
        foreach (var lesser in LesserValuesThatAreInvalid)
        {
            var exception = Record.Exception(() => Contract.For(lesser.Value).Lesser(lesser.Max).Ok());
            exception.Should().NotBeNull();
        }
    }
}