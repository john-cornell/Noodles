using Noodles.MeansCalculations;
using System.Collections.Generic;

namespace Noodles.AggregationProperties
{
    public interface IAggregationProperty
    {
        bool Test(IEnumerable<float> values, IMeanCalculator calculator, AggregationProperty.AggregationTestTypes method = AggregationProperty.AggregationTestTypes.Default);
        bool Test(IEnumerable<int> values, IMeanCalculator calculator, AggregationProperty.AggregationTestTypes method);
    }
}