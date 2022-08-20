using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class StringTests
    {
        [Theory]
        [InlineData("Foo", false)]
        [InlineData(null, true)]
        public void NotNull_Requirement_Successful_Asserts(string value, bool throws)
        {
            var exception = Record.Exception(() => Contract.For(value).NotNull().Ok());

            var hasThrown = exception != null;
            hasThrown.Should().Be(throws);
        }
    }
}
