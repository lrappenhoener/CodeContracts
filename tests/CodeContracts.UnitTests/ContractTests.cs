using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeContracts.UnitTests
{
    public class ContractTests
    {
        [Fact]
        public void Requires_Successful_Validates_Valid_Requirements()
        {
            var requirements = CreateValidRequirements();
            
            var exception = Record.Exception(() => Contract.Requires(requirements));

            exception.Should().BeNull();
        }

        private ContractRequirements<double> CreateValidRequirements()
        {
            var target = 50.0d;

            return Requirements
                .For(target)
                .Lesser(100.0d)
                .Greater(25.0d)
                .InRange(45.0d, 55.0d)
                .GreaterEquals(target)
                .LesserEquals(target)
                .Positive();
        }
    }
}
