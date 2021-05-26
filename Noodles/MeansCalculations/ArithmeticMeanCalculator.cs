using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.MeansCalculations
{
    public class ArithmeticMeanCalculator
    {
        public ArithmeticMeanCalculator()
        {

        }

        public int Calculate(IEnumerable<int> values) => values == null ? 0 : values.Sum() / values.Count();
    }
}
