using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class GeometricMeanCalculator
    {
        public double Calculate(IEnumerable<double> values)
        {
            //return CalculateWithLog(values);

            if (values == null || values.Count() == 0) return 0;

            double product = values.Select(i => (double)i).Aggregate((acc, val) => ((double)acc * (double)val));

            return Math.Pow(product, 1d / (double)values.Count());
        }

        public double CalculateWithLog(IEnumerable<double> values)
        {

            if (values == null || values.Count() == 0) return 0;

            double logSum = values.Select(i => Math.Log(i)).Sum();

            return logSum / (double)values.Count();
        }

        public double Calculate(IEnumerable<int> values)
        {
            if (values == null || values.Count() == 0) return 0;

            return Calculate(values.Select(i => (double)i));
        }
    }
}
