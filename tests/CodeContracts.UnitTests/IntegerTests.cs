using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class IntegerTests
    {
        [Theory]
        [InlineData(int.MaxValue, false)]
        [InlineData(1, false)]
        [InlineData(0, false)]
        [InlineData(-1, true)]
        [InlineData(int.MinValue, true)]
        public void Positive_Requirement_Successful_Asserts_Int(int number, bool throws)
        {
            var exception = Record.Exception(() =>
                Contract.For(number).Positive().Ok());

            (exception != null).Should().Be(throws);
        }
    }
}
