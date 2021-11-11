using System.Collections.Generic;
using System.Linq;

namespace Noodles.MeansCalculations
{
    public class HarmonicMeanCalculator : MeanCalculator
    {
        protected override decimal InternalCalculate(IEnumerable<decimal> values) =>
            values.Count() /
                (
                    values.Select(v => 1m / v).Sum()
                );

    }
}
