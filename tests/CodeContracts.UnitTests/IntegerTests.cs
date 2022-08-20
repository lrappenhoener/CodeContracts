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
        protected override int Zero => 0;
        protected override int Positive => 1;
        protected override int Negative => -1;
        protected override int Max => int.MaxValue;
        protected override int Min => int.MinValue;
    }
}
