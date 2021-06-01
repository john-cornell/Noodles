using Noodles.MeansCalculations;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.AggregationProperties
{
    public abstract class AggregationProperty : IAggregationProperty
    {
        public enum AggregationTestTypes : long
        {
            Default = 0,
            Symmetry_Shuffle = 1L << 0,
            Symmetry_Cycle = 1L << 1,
        }


        public abstract bool Test(IEnumerable<double> values, IMeanCalculator calculator, AggregationTestTypes method = AggregationTestTypes.Default);
        public bool Test(IEnumerable<int> values, IMeanCalculator calculator, AggregationTestTypes method = AggregationTestTypes.Default) => Test(values.Select(v => (double)v), calculator, method);
    }
}