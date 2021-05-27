using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator
    {
        public double Calculate(IEnumerable<double> values) =>
            values == null || values.Count() == 0 ?
                0 :
                values.Select(i => (double)i).Sum() / ((double)values.Count());

        public double Calculate(IEnumerable<int> values)
        {
            if (values == null || values.Count() == 0) return 0;

            return Calculate(values.Select(i => (double)i));
        }
    }
}
