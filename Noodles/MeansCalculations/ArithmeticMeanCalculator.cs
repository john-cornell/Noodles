using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator : MeanCalculator
    {
        protected override double InternalCalculate(IEnumerable<double> values) =>
            values.Select(i => (double)i).Sum() / ((double)values.Count());
    }
}
