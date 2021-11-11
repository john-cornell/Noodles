using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.MeansCalculations;

namespace Noodles.AggregationProperties
{
    public class TranslationInvarianceAggregationProperty : AggregationProperty
    {
        Random _random;
        int TEST_ITERATIONS = 100;

        public TranslationInvarianceAggregationProperty()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public override bool Test(IEnumerable<decimal> values, IMeanCalculator calculator, AggregationTestTypes method = AggregationTestTypes.Default)
        {
            decimal raw = calculator.Calculate(values);

            if (method != AggregationTestTypes.Default) throw new InvalidOperationException($"Invalid Aggregation Test Type {method}");

            for (int i = 1; i < TEST_ITERATIONS; i++)
            {
                decimal constant = 0.98m;// (float)(decimal)Math.Round(_random.Nextfloat(), 2);

                decimal expected = raw + constant;

                decimal newMean = calculator.Calculate(values.Select(v => v + constant));

                if (newMean != expected) return false;
            }

            return true;
        }
    }
}
