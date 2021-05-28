using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator : MeanCalculator
    {
        public override double Calculate(IEnumerable<double> values) =>
            values == null || values.Count() == 0 ?
                0 :
                values.Select(i => (double)i).Sum() / ((double)values.Count());
    }
}
