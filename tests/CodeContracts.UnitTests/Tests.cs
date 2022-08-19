using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class Tests
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
    }
}
