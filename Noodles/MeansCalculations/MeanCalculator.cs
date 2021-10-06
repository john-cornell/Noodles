using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public abstract class MeanCalculator : IMeanCalculator
    {
        public float Calculate(IEnumerable<float> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return InternalCalculate(values);
        }

        protected abstract float InternalCalculate(IEnumerable<float> values);

        public float Calculate(IEnumerable<int> values)
        {
            if (values == null) throw new ArgumentNullException("values");

            if (values.Count() == 0) return 0;

            return Calculate(values.Select(i => (float)i));
        }

        //Yucky brute force - lack of decimal 
    }
}
