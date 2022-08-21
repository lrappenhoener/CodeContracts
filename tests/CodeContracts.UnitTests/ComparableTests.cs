using FluentAssertions;

// ReSharper disable VirtualMemberCallInConstructor

namespace CodeContracts.UnitTests;

public abstract class ComparableTests<T> where T : IComparable
{
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

        RangesThatAreValid = new List<Range<T>>
        {
            new(Zero, Negative, Positive),
            new(Zero, Min, Max),
            new(Positive, Negative, Positive),
            new(Negative, Negative, Positive),
            new(Negative, Min, Positive)
        };

        RangesThatAreInvalid = new List<Range<T>>
        {
            new(Zero, Positive, Max),
            new(Zero, Min, Negative)
        };

        LesserValuesThatAreValid = new List<Compare<T>>
        {
            new(Zero, Positive),
            new(Negative, Zero),
            new(Positive, Max)
        };

        LesserValuesThatAreInvalid = new List<Compare<T>>
        {
            new(Positive, Zero),
            new(Positive, Positive),
            new(Zero, Negative),
            new(Zero, Zero),
            new(Max, Positive),
            new(Max, Max)
        };

        LesserEqualsValuesThatAreValid = new List<Compare<T>>
        {
            new(Zero, Positive),
            new(Zero, Zero),
            new(Negative, Zero),
            new(Negative, Negative),
            new(Positive, Max),
            new(Positive, Positive),
            new(Min, Min),
            new(Max, Max)
        };

        LesserEqualsValuesThatAreInvalid = new List<Compare<T>>
        {
            new(Positive, Zero),
            new(Zero, Negative),
            new(Max, Positive)
        };

        GreaterValuesThatAreValid = new List<Compare<T>>
        {
            new(Positive, Zero),
            new(Zero, Negative),
            new(Max, Positive)
        };

        GreaterValuesThatAreInvalid = new List<Compare<T>>
        {
            new(Zero, Positive),
            new(Zero, Zero),
            new(Negative, Zero),
            new(Negative, Negative),
            new(Positive, Max),
            new(Positive, Positive),
            new(Max, Max),
            new(Min, Min)
        };

        GreaterEqualsValuesThatAreValid = new List<Compare<T>>
        {
            new(Positive, Zero),
            new(Positive, Positive),
            new(Zero, Negative),
            new(Zero, Zero),
            new(Max, Positive),
            new(Max, Max)
        };

        GreaterEqualsValuesThatAreInvalid = new List<Compare<T>>
        {
            new(Zero, Positive),
            new(Negative, Zero),
            new(Positive, Max),
            new(Min, Negative)
        };
    }

    protected abstract T Zero { get; }
    protected abstract T Positive { get; }
    protected abstract T Negative { get; }
    protected abstract T Max { get; }
    protected abstract T Min { get; }

    protected IEnumerable<T> PositiveValues { get; }
    protected IEnumerable<T> NegativeValues { get; }
    protected IEnumerable<Range<T>> RangesThatAreValid { get; }
    protected IEnumerable<Range<T>> RangesThatAreInvalid { get; }
    protected IEnumerable<Compare<T>> LesserValuesThatAreValid { get; }
    protected IEnumerable<Compare<T>> LesserValuesThatAreInvalid { get; }
    protected IEnumerable<Compare<T>> LesserEqualsValuesThatAreValid { get; }
    protected IEnumerable<Compare<T>> LesserEqualsValuesThatAreInvalid { get; }
    protected IEnumerable<Compare<T>> GreaterValuesThatAreValid { get; }
    protected IEnumerable<Compare<T>> GreaterValuesThatAreInvalid { get; }
    protected IEnumerable<Compare<T>> GreaterEqualsValuesThatAreValid { get; }
    protected IEnumerable<Compare<T>> GreaterEqualsValuesThatAreInvalid { get; }

    [Fact]
    public void Positive_Requirement_Successful_Validates_Positive_Values()
    {
        PositiveValues.All(v => Requirements.For(v).Positive().Ok(v)).Should().BeTrue();
    }

    [Fact]
    public void Positive_Requirement_Successful_Validates_Negative_Values()
    {
        NegativeValues.All(v => !Requirements.For(v).Positive().Ok(v)).Should().BeTrue();
    }

    [Fact]
    public void Negative_Requirement_Successful_Validates_Negative_Values()
    {
        NegativeValues.All(v => Requirements.For(v).Negative().Ok(v)).Should().BeTrue();
    }

    [Fact]
    public void Negative_Requirement_Successful_Validates_Positive_Values()
    {
        PositiveValues.All(v => !Requirements.For(v).Negative().Ok(v)).Should().BeTrue();
    }

    [Fact]
    public void InRange_Requirement_Successful_Validates_Valid_Ranges()
    {
        RangesThatAreValid.All(r => Requirements.For(r.Value).InRange(r.Min, r.Max).Ok(r.Value)).Should().BeTrue();
    }

    [Fact]
    public void InRange_Requirement_Successful_Validates_Invalid_Ranges()
    {
        RangesThatAreInvalid.All(r => !Requirements.For(r.Value).InRange(r.Min, r.Max).Ok(r.Value)).Should().BeTrue();
    }

    [Fact]
    public void Lesser_Requirement_Successful_Validates_Valid_Values()
    {
        LesserValuesThatAreValid.All(v => Requirements.For(v.Value).Lesser(v.Max).Ok(v.Value)).Should().BeTrue();
    }

    [Fact]
    public void Lesser_Requirement_Successful_Validates_Invalid_Values()
    {
        LesserValuesThatAreInvalid.All(v => !Requirements.For(v.Value).Lesser(v.Max).Ok(v.Value)).Should().BeTrue();
    }

    [Fact]
    public void Greater_Requirement_Successful_Validates_Valid_Values()
    {
        GreaterValuesThatAreValid.All(greater => Requirements.For(greater.Value).Greater(greater.Max).Ok(greater.Value)).Should().BeTrue();
    }

    [Fact]
    public void Greater_Requirement_Successful_Validates_Invalid_Values()
    {
        GreaterValuesThatAreInvalid.All(greater => !Requirements.For(greater.Value).Greater(greater.Max).Ok(greater.Value)).Should().BeTrue();
    }

    [Fact]
    public void GreaterEquals_Requirement_Successful_Validates_Valid_Values()
    {
        GreaterEqualsValuesThatAreValid.All(greater => Requirements.For(greater.Value).GreaterEquals(greater.Max).Ok(greater.Value)).Should().BeTrue();
    }

    [Fact]
    public void GreaterEquals_Requirement_Successful_Validates_Invalid_Values()
    {
        GreaterEqualsValuesThatAreInvalid.All(greater => !Requirements.For(greater.Value).GreaterEquals(greater.Max).Ok(greater.Value)).Should().BeTrue();
    }

    [Fact]
    public void LesserEquals_Requirement_Successful_Validates_Valid_Values()
    {
        LesserEqualsValuesThatAreValid
            .All(lesserEquals => Requirements.For(lesserEquals.Value).LesserEquals(lesserEquals.Max).Ok(lesserEquals.Value)).Should()
            .BeTrue();
    }

    [Fact]
    public void LesserEquals_Requirement_Successful_Validates_InvalidValues()
    {
        LesserEqualsValuesThatAreInvalid
            .All(lesserEquals => !Requirements.For(lesserEquals.Value).LesserEquals(lesserEquals.Max).Ok(lesserEquals.Value)).Should()
            .BeTrue();
    }

    [Fact]
    public void Multiple_Requirements_When_Valid_Does_Not_Throw()
    {
        var target = Positive;

        var valid = Requirements
                .For(target)
                .Lesser(Max)
                .Greater(Min)
                .InRange(Min, Max)
                .GreaterEquals(Positive)
                .LesserEquals(Positive)
                .Positive()
                .Ok(target);

        valid.Should().BeTrue();
    }

    [Fact]
    public void Multiple_Requirements_When_Not_All_Are_Valid_Does_Throw()
    {
        var target = Positive;

        var valid = Requirements
                .For(target)
                .Lesser(Max)
                .Greater(Min)
                .InRange(Min, Max)
                .Negative()
                .GreaterEquals(Positive)
                .LesserEquals(Positive)
                .Positive()
                .Ok(target);

        valid.Should().BeFalse();
    }

    [Fact]
    public void Ok_With_No_Requirements_Not_Throws()
    {
        var target = Positive;

        var valid = Requirements.For(target).Ok(target);

        valid.Should().BeTrue();
    }
}