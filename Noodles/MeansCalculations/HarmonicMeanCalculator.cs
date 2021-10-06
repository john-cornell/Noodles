using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class HarmonicMeanCalculator : MeanCalculator
    {
        protected override float InternalCalculate(IEnumerable<float> values) =>
            values.Count() /
                (
                    values.Select(v => 1f / v).Sum()
                );

    }
}
