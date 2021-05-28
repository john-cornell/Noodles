using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class MedianCalculator : MeanCalculator
    {
        protected override double InternalCalculate(IEnumerable<double> values)
        {
            int count = values.Count();
            int mid = count / 2; //int calculation, so if even, will return Floor value (remove 0.5)
            if (count % 2 == 0)
            {
                return values.ElementAt(mid) + values.ElementAt(mid + 1);
            }
            else
            {
                return values.ElementAt(mid + 1);
            }
        }
    }
}
