using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator : MeanCalculator
    {
        protected override float InternalCalculate(IEnumerable<float> values)// =>
        {
            float sum = values.Select(i => (float)i).Sum();
            float count = ((float)values.Count());

            return sum / count;
        }            
    }
}
