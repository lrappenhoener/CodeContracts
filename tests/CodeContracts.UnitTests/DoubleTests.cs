using FluentAssertions;

namespace CodeContracts.UnitTests;

public class DoubleTests
{
    [Theory]
    [InlineData(double.MaxValue, false)]
    [InlineData(1.0, false)]
    [InlineData(0.0, false)]
    [InlineData(-1.0, true)]
    [InlineData(double.MinValue, true)]
    public void Positive_Requirement_Successful_Asserts_Double(double number, bool throws)
    {
        var exception = Record.Exception(() =>
            Contract.For(number).Positive().Ok());

        (exception != null).Should().Be(throws);
    }
}