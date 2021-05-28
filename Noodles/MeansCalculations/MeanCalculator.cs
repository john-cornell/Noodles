using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public abstract class MeanCalculator : IMeanCalculator
    {
        public double Calculate(IEnumerable<double> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return InternalCalculate(values);
        }

        protected abstract double InternalCalculate(IEnumerable<double> values);

        public double Calculate(IEnumerable<int> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return Calculate(values.Select(i => (double)i));
        }
    }
}
