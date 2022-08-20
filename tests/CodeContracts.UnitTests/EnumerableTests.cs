﻿using System.Collections;
using FluentAssertions;

namespace CodeContracts.UnitTests;

public class EnumerableTests
{
    [Fact]
    public void NotNull_Requirement_When_Null_Throws()
    {
        IEnumerable? enumerable = null;

        var exception = Record.Exception(() => Contract.For(enumerable).NotNull().Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void NotNull_Requirement_When_Not_Null_Does_Not_Throw()
    {
        IEnumerable enumerable = new ArrayList();

        var exception = Record.Exception(() => Contract.For(enumerable).NotNull().Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_When_Null_Throws()
    {
        IEnumerable? enumerable = null;

        var exception = Record.Exception(() => Contract.For(enumerable).NotNullOrEmpty().Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_When_Empty_Throws()
    {
        IEnumerable enumerable = new ArrayList();

        var exception = Record.Exception(() => Contract.For(enumerable).NotNullOrEmpty().Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void NotNullOrEmpty_Requirement_When_Not_Empty_Does_Not_Throw()
    {
        IEnumerable enumerable = new ArrayList { "foo" };

        var exception = Record.Exception(() => Contract.For(enumerable).NotNullOrEmpty().Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void Multiple_Requirements_When_Valid_Does_Not_Throw()
    {
        var target = new ArrayList { "foo" };

        var exception = Record.Exception(() =>
            Contract.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .Ok());

        exception.Should().BeNull();
    }

    [Fact]
    public void Multiple_Requirements_When_Not_All_Valid_Does_Throw()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var target = new ArrayList();

        var exception = Record.Exception(() =>
            Contract.For(target)
                .NotNull()
                .NotNullOrEmpty()
                .Ok());

        exception.Should().NotBeNull();
    }

    [Fact]
    public void Ok_With_No_Requirements_Not_Throws()
    {
        IEnumerable? target = null;

        var exception = Record.Exception(() =>
            Contract.For(target).Ok());

        exception.Should().BeNull();
    }
}