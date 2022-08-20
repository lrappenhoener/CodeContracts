using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class EnumerableTests
    {
        [Fact]
        public void NotNull_Requirement_When_Null_Throws()
        {
            IEnumerable enumerable = null;

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
        public void NotEmpty_Requirement_When_Null_Throws()
        {
            IEnumerable enumerable = null;

            var exception = Record.Exception(() => Contract.For(enumerable).NotNullOrEmpty().Ok());

            exception.Should().NotBeNull();
        }

    }
}
