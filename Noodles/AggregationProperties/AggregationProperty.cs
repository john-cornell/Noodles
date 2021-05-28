using Noodles.MeansCalculations;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.AggregationProperties
{
    public abstract class AggregationProperty : IAggregationProperty
    {
        public abstract bool Test(IEnumerable<double> values, IMeanCalculator calculator);
        public bool Test(IEnumerable<int> values, IMeanCalculator calculator) => Test(values.Select(v => (double)v), calculator);
    }
}