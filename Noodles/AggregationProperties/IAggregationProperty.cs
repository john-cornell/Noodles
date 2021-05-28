using Noodles.MeansCalculations;
using System.Collections.Generic;

namespace Noodles.AggregationProperties
{
    public interface IAggregationProperty
    {
        bool Test(IEnumerable<double> values, IMeanCalculator calculator);
        bool Test(IEnumerable<int> values, IMeanCalculator calculator);
    }
}