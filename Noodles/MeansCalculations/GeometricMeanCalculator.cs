using System;
using System.Collections.Generic;
using System.Linq;
using RDotNet;

namespace Noodles.MeansCalculations
{
    public class GeometricMeanCalculator : MeanCalculator
    {

        protected override float InternalCalculate(IEnumerable<float> values)
        {
            REngine.SetEnvironmentVariables();
            //using (REngine engine = REngine.GetInstance())
            throw new NotImplementedException();
        }
        protected float InternalCalculatex(IEnumerable<float> values)
        {
            float product = values.Select(i => (float)i).Aggregate((acc, val) => ((float)acc * (float)val));

            return MathF.Pow(product, 1f / (float)values.Count());
        }
    }
}
