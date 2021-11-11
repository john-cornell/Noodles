using System.Collections.Generic;

namespace Noodles.MeansCalculations
{
    public interface IMeanCalculator
    {
        decimal Calculate(IEnumerable<decimal> values);
        decimal Calculate(IEnumerable<int> values);
    }
}