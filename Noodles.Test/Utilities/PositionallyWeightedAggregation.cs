using Noodles.Extensions;
using Noodles.MeansCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.Test.Utilities
{
    public class PositionallyWeightedAggregation : MeanCalculator
    {
        protected override double InternalCalculate(IEnumerable<double> values)
        {
            double result = 0;
            int n = values.Count();

            values.Index((i, v) => 
            {
                result += v * (n / (i + 1));
            });
            return result;
        }
    }
}
