using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator : MeanCalculator
    {
        protected override decimal InternalCalculate(IEnumerable<decimal> values)// =>
        {
            decimal sum = values.Select(i => (decimal)i).Sum();
            decimal count = ((decimal)values.Count());

            return sum / count;
        }            
    }
}
