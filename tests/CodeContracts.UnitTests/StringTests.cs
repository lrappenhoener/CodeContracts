using FluentAssertions;

namespace CodeContracts.UnitTests;

public class StringTests
{
    [Theory]
    [InlineData("Foo", true)]
    [InlineData(null, false)]
    [InlineData("", true)]
    [InlineData("  ", true)]
    public void NotNull_Requirement_Successful_Validates(string value, bool throws)
    {
        var valid = Requirements.For(value).NotNull().Ok(value);
        
        valid.Should().Be(throws);
    }

    [Theory]
    [InlineData("Foo", true)]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData("  ", true)]
    public void NotNullOrEmpty_Requirement_Successful_Asserts(string value, bool throws)
    {
        var valid = Requirements.For(value).NotNullOrEmpty().Ok(value);
        
        valid.Should().Be(throws);
    }

    [Theory]
    [InlineData("Foo", true)]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("     ", false)]
    public void NotNullEmptyWhitespace_Requirement_Successful_Asserts(string value, bool throws)
    {
        var valid = Requirements.For(value).NotNullOrEmptyOrWhitespace().Ok(value);
        
        valid.Should().Be(throws);
    }

    [Fact]
    public void Multiple_Requirements_Successful_Validates_Valid_Value()
    {
        var target = "foo";
        var valid = 
            Requirements.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .NotNullOrEmptyOrWhitespace()
                .Ok(target);

        valid.Should().BeTrue();
    }

    [Fact]
    public void Multiple_Requirements_Successful_Validates_Invalid_Value()
    {
        var target = " ";
        var valid = 
            Requirements.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .NotNullOrEmptyOrWhitespace()
                .Ok(target);

        valid.Should().BeFalse();
    }

    [Fact]
    public void Ok_With_No_Requirements_Returns_True()
    {
        string? target = null;

        var valid = 
            Requirements.For(target).Ok(target);

        valid.Should().BeTrue();
    }
}