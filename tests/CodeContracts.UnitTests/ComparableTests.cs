using FluentAssertions;

namespace CodeContracts.UnitTests;

public abstract class ComparableTests<T> where T : IComparable
{
    protected abstract IEnumerable<T> PositiveValues { get; }
    protected abstract IEnumerable<T> NegativeValues { get; }

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
}