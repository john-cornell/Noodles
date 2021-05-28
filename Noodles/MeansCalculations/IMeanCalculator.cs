using System.Collections.Generic;

namespace Noodles.MeansCalculations
{
    public interface IMeanCalculator
    {
        double Calculate(IEnumerable<double> values);
        double Calculate(IEnumerable<int> values);
    }
}