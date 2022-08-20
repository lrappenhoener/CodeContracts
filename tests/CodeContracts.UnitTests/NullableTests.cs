using FluentAssertions;

namespace CodeContracts.UnitTests;

public class NullableTests
{
    [Fact]
    public void NotNull_Requirement_When_Null_Fails()
    {
        object? target = null;
        var exception = Record.Exception(() => Contract.For(target).NotNull().Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void NotNull_Requirement_When_NotNull_Successful()
    {
        var target = new object();
        var exception = Record.Exception(() => Contract.For(target).NotNull().Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void Ok_With_No_Requirements_Not_Throws()
    {
        object? target = null;

        var exception = Record.Exception(() =>
            Contract.For(target).Ok());

        exception.Should().BeNull();
    }
}