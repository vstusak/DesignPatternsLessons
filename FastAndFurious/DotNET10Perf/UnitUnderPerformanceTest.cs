using System;
using System.Collections.Generic;
using System.Text;

namespace DotNET10Perf
{
    public class UnitUnderPerformanceTest
    {
        public int Test4(IEnumerable<int> values)
        {
            int summary = 0;

            foreach (int item in values)
            {
                summary += item;
            }

            return summary;
        }
    }
}
