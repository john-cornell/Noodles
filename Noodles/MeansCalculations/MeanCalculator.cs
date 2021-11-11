using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.MeansCalculations
{
    public abstract class MeanCalculator : IMeanCalculator
    {
        public decimal Calculate(IEnumerable<decimal> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return InternalCalculate(values);
        }

        protected abstract decimal InternalCalculate(IEnumerable<decimal> values);

        public decimal Calculate(IEnumerable<int> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return Calculate(values.Select(i => (decimal)i));
        }
    }
}
