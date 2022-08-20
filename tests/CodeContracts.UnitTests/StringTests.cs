using FluentAssertions;
using PCC.Libraries.CodeContracts;

namespace CodeContracts.UnitTests;

public class StringTests
{
    [Theory]
    [InlineData("Foo", false)]
    [InlineData(null, true)]
    [InlineData("", false)]
    [InlineData("  ", false)]
    public void NotNull_Requirement_Successful_Asserts(string value, bool throws)
    {
        var exception = Record.Exception(() => Contract.For(value).NotNull().Ok());

        var hasThrown = exception != null;
        hasThrown.Should().Be(throws);
    }

    [Theory]
    [InlineData("Foo", false)]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("  ", false)]
    public void NotNullOrEmpty_Requirement_Successful_Asserts(string value, bool throws)
    {
        var exception = Record.Exception(() => Contract.For(value).NotNullOrEmpty().Ok());

        var hasThrown = exception != null;
        hasThrown.Should().Be(throws);
    }

    [Theory]
    [InlineData("Foo", false)]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("     ", true)]
    public void NotNullEmptyWhitespace_Requirement_Successful_Asserts(string value, bool throws)
    {
        var exception = Record.Exception(() => Contract.For(value).NotNullOrEmptyOrWhitespace().Ok());

        var hasThrown = exception != null;
        hasThrown.Should().Be(throws);
    }

    [Fact]
    public void Multiple_Requirements_When_All_Valid_Does_Not_Throw()
    {
        var target = "foo";
        var exception = Record.Exception(() =>
            Contract.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .NotNullOrEmptyOrWhitespace()
                .Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void Multiple_Requirements_When_Not_All_Valid_Does_Throw()
    {
        var target = " ";
        var exception = Record.Exception(() =>
            Contract.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .NotNullOrEmptyOrWhitespace()
                .Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void Ok_With_No_Requirements_Not_Throws()
    {
        string? target = null;

        var exception = Record.Exception(() =>
            Contract.For(target).Ok());

        exception.Should().BeNull();
    }
}