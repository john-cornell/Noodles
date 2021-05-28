using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class GeometricMeanCalculator : MeanCalculator
    {
        public override double Calculate(IEnumerable<double> values)
        {
            if (values == null || values.Count() == 0) return 0;

            double product = values.Select(i => (double)i).Aggregate((acc, val) => ((double)acc * (double)val));

            return Math.Pow(product, 1d / (double)values.Count());
        }        
    }
}
