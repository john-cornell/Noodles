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
        public SymmetryAggregationProperty()
        {

        }

        public override bool Test(IEnumerable<float> values, IMeanCalculator calculator, AggregationTestTypes method = AggregationTestTypes.Default)
        {
            bool @default = (int)(method & AggregationTestTypes.Default) != 0;
            bool shuffle = (int)(method & AggregationTestTypes.Symmetry_Shuffle) != 0 || @default;
            bool cycle = (int)(method & AggregationTestTypes.Symmetry_Cycle) != 0 || @default;

            float raw = calculator.Calculate(values);

            if (!(shuffle || cycle)) throw new InvalidOperationException($"Invalid Aggregation Test Type {method}");

            if (shuffle)
            {
                int n = values.Count();

                for (int i = 1; i < n; i++)
                {
                    float shuffled = calculator.Calculate(values.Shuffle());

                    if (raw != shuffled) return false;
                }
            }

            if (cycle)
            {
                foreach (IEnumerable<float> cycled in values.Cycle())
                {
                    if (raw != calculator.Calculate(cycled)) return false;
                }
            }

            return true;
        }
    }
}
