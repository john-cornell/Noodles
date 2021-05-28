using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class GeometricMeanCalculator : MeanCalculator
    {
        protected override double InternalCalculate(IEnumerable<double> values)
        {            
            double product = values.Select(i => (double)i).Aggregate((acc, val) => ((double)acc * (double)val));

            return Math.Pow(product, 1d / (double)values.Count());
        }        
    }
}
