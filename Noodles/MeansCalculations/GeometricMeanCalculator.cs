using System;
using System.Collections.Generic;
using System.Linq;
using RDotNet;

namespace Noodles.MeansCalculations
{
    public class GeometricMeanCalculator : MeanCalculator
    {

        protected decimal InternalCalculatex(IEnumerable<decimal> values)
        {
            REngine.SetEnvironmentVariables();
            //using (REngine engine = REngine.GetInstance())
            throw new NotImplementedException();
        }
        protected override decimal InternalCalculate(IEnumerable<decimal> values)
        {
            decimal product = values.Select(i => (decimal)i).Aggregate((acc, val) => ((decimal)acc * (decimal)val));

            return (decimal)Math.Pow((double)product, (double)(1m / (decimal)values.Count()));
        }
    }
}
