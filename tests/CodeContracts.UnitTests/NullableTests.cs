using FluentAssertions;

namespace CodeContracts.UnitTests;

public class NullableTests
{
    [Fact]
    public void NotNull_Requirement_Successful_Validates_Null()
    {
        object? target = null;

        var valid = Requirements.For(target).NotNull().Ok(target);

        valid.Should().BeFalse();
    }

    [Fact]
    public void NotNull_Requirement_Successful_Validates_NonNull()
    {
        var target = new object();

        var valid = Requirements.For(target).NotNull().Ok(target);

        valid.Should().BeTrue();
    }

    [Fact]
    public void Ok_With_No_Requirements_Returns_True()
    {
        object? target = null;

        var valid = Requirements.For(target).Ok(target);

        valid.Should().BeTrue();
    }
}