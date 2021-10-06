using System.Collections.Generic;

namespace Noodles.MeansCalculations
{
    public interface IMeanCalculator
    {
        float Calculate(IEnumerable<float> values);
        float Calculate(IEnumerable<int> values);
    }
}