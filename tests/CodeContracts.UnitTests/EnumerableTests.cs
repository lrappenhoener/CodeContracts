using System.Collections;
using FluentAssertions;

namespace CodeContracts.UnitTests;

public class EnumerableTests
{
    [Fact]
    public void NotNull_Requirement_Successful_Validates_Null_Value()
    {
        IEnumerable? enumerable = null;

        Requirements.For(enumerable).NotNull().Ok(enumerable)
            .Should().BeFalse();
    }

    [Fact]
    public void NotNull_Requirement_Successful_Validates_Non_Null_Value()
    {
        IEnumerable enumerable = new ArrayList();

        Requirements.For(enumerable).NotNull().Ok(enumerable).Should().BeTrue();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_Successful_Validates_Null_Value()
    {
        IEnumerable? enumerable = null;

        Requirements.For(enumerable).NotNullOrEmpty().Ok(enumerable).Should().BeFalse();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_Successful_Validates_Empty_Value()
    {
        IEnumerable enumerable = new ArrayList();

        Requirements.For(enumerable).NotNullOrEmpty().Ok(enumerable).Should().BeFalse();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_Successful_Validates_Non_Empty_Value()
    {
        IEnumerable enumerable = new ArrayList { "foo" };

        Requirements.For(enumerable).NotNullOrEmpty().Ok(enumerable).Should().BeTrue();
    }

    [Fact]
    public void Multiple_Requirements_Successful_Validates_Valid_Values()
    {
        var target = new ArrayList { "foo" };

        var valid = Requirements.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .Ok(target);

        valid.Should().BeTrue();
    }

    [Fact]
    public void Multiple_Requirements_Successful_Validates_Invalid_Values()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var target = new ArrayList();

        var valid = Requirements.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .Ok(target);

        valid.Should().BeFalse();
    }

    [Fact]
    public void Ok_With_No_Requirements_Returns_True()
    {
        IEnumerable? target = null;

        var valid = Requirements.For(target).Ok(target);

        valid.Should().BeTrue();
    }
}