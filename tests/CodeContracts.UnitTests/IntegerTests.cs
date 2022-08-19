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

        protected override IEnumerable<Range> RangesThatAreValid { get; } = new List<Range>
        {
            new Range(0, 0, 1),
            new Range(0, -1, 0),
            new Range(-1, -1, 0),
            new Range(-1, -1, 1),
            new Range(int.MinValue, int.MinValue, 1),
            new Range(int.MaxValue, int.MaxValue - 1, int.MaxValue),
        };
    }
}
