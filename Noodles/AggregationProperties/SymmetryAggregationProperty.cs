using Noodles.Extensions;
using Noodles.MeansCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.AggregationProperties
{
    public class SymmetryAggregationProperty : AggregationProperty
    {
        public override bool Test(IEnumerable<double> values, IMeanCalculator calculator, AggregationTestTypes method = AggregationTestTypes.Default)
        {
            bool shuffle = (int)(method & AggregationTestTypes.Symmetry_Shuffle) != 0;
            bool cycle = (int)(method & AggregationTestTypes.Symmetry_Cycle) != 0;

            double raw = calculator.Calculate(values);

            if (shuffle)
            {
                int n = values.Count();

                for (int i = 1; i < n; i++)
                {                    
                    double shuffled = calculator.Calculate(values.Shuffle());

                    if (raw != shuffled) return false;
                }
            }

            if (cycle)
            {
                foreach(IEnumerable<double> cycled in values.Cycle())
                {
                    if (raw != calculator.Calculate(cycled)) return false;
                }
            }

            return true;
        }
    }
}
