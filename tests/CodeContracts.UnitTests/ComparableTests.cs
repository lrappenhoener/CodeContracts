﻿using FluentAssertions;

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

    [Fact]
    public void Greater_Requirement_Successful_Asserts_ValidValues()
    {
        foreach (var greater in GreaterValuesThatAreValid)
        {
            var exception = Record.Exception(() => Contract.For(greater.Value).Greater(greater.Max).Ok());
            exception.Should().BeNull();
        }
    }

    [Fact]
    public void Greater_Requirement_Successful_Asserts_InvalidValues()
    {
        foreach (var greater in GreaterValuesThatAreInvalid)
        {
            var exception = Record.Exception(() => Contract.For(greater.Value).Greater(greater.Max).Ok());
            exception.Should().NotBeNull();
        }
    }

    [Fact]
    public void GreaterEquals_Requirement_Successful_Asserts_ValidValues()
    {
        foreach (var greaterEquals in GreaterEqualsValuesThatAreValid)
        {
            var exception =
                Record.Exception(() => Contract.For(greaterEquals.Value).GreaterEquals(greaterEquals.Max).Ok());
            exception.Should().BeNull();
        }
    }

    [Fact]
    public void GreaterEquals_Requirement_Successful_Asserts_InvalidValues()
    {
        foreach (var greaterEquals in GreaterEqualsValuesThatAreInvalid)
        {
            var exception =
                Record.Exception(() => Contract.For(greaterEquals.Value).GreaterEquals(greaterEquals.Max).Ok());
            exception.Should().NotBeNull();
        }
    }

    [Fact]
    public void LesserEquals_Requirement_Successful_Asserts_ValidValues()
    {
        foreach (var lesserEquals in LesserEqualsValuesThatAreValid)
        {
            var exception =
                Record.Exception(() => Contract.For(lesserEquals.Value).LesserEquals(lesserEquals.Max).Ok());
            exception.Should().BeNull();
        }
    }

    [Fact]
    public void LesserEquals_Requirement_Successful_Asserts_InvalidValues()
    {
        foreach (var lesserEquals in LesserEqualsValuesThatAreInvalid)
        {
            var exception =
                Record.Exception(() => Contract.For(lesserEquals.Value).LesserEquals(lesserEquals.Max).Ok());
            exception.Should().NotBeNull();
        }
    }

    [Fact]
    public void Multiple_Requirements_When_Valid_Does_Not_Throw()
    {
        var target = Positive;

        var exception = Record.Exception(() =>
            Contract
                .For(target)
                .Lesser(Max)
                .Greater(Min)
                .InRange(Min, Max)
                .GreaterEquals(Positive)
                .LesserEquals(Positive)
                .Positive()
                .Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void Multiple_Requirements_When_Not_All_Are_Valid_Does_Throw()
    {
        var target = Positive;

        var exception = Record.Exception(() =>
            Contract
                .For(target)
                .Lesser(Max)
                .Greater(Min)
                .InRange(Min, Max)
                .Negative()
                .GreaterEquals(Positive)
                .LesserEquals(Positive)
                .Positive()
                .Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void Ok_With_No_Requirements_Not_Throws()
    {
        var target = Positive;

        var exception = Record.Exception(() =>
            Contract.For(target).Ok());

        exception.Should().BeNull();
    }
}