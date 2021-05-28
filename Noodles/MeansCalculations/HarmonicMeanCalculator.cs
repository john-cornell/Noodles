using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class HarmonicMeanCalculator : MeanCalculator
    {
        protected override double InternalCalculate(IEnumerable<double> values) =>
            values.Count() /
                (
                    values.Select(v => 1d / v).Sum()
                );

    }
}
