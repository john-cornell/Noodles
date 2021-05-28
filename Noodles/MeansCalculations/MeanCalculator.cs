using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public abstract class MeanCalculator : IMeanCalculator
    {
        public abstract double Calculate(IEnumerable<double> values);

        public double Calculate(IEnumerable<int> values)
        {
            if (values == null || values.Count() == 0) return 0;

            return Calculate(values.Select(i => (double)i));
        }
    }
}
