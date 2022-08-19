using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContracts.UnitTests
{
    public class IntegerTests : ComparableTests<int>
    {
        protected override IEnumerable<int> PositiveValues { get; } = new List<int>
        {
            0,
            1,
            int.MaxValue
        };

        protected override IEnumerable<int> NegativeValues { get; } = new List<int>
        {
            -1,
            int.MinValue
        };
    }
}
