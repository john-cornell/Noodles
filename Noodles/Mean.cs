using System.Collections.Generic;
using Noodles.MeansCalculations;

namespace Noodles
{
    public class Mean
    {
        ArithmeticMeanCalculator _arithmetic;
        GeometricMeanCalculator _geometric;
        HarmonicMeanCalculator _harmonic;
        MedianCalculator _median;
        public Mean()
        {
            _arithmetic = new ArithmeticMeanCalculator();
            _geometric = new GeometricMeanCalculator();
            _harmonic = new HarmonicMeanCalculator();
            _median = new MedianCalculator();
        }

        public decimal Arithmetic(IEnumerable<int> values) => _arithmetic.Calculate(values);
        public decimal Arithmetic(IEnumerable<decimal> values) => _arithmetic.Calculate(values);

        public decimal Geometric(IEnumerable<int> values) => _geometric.Calculate(values);
        public decimal Geometric(IEnumerable<decimal> values) => _geometric.Calculate(values);

        public decimal Harmonic(IEnumerable<int> values) => _harmonic.Calculate(values);
        public decimal Harmonic(IEnumerable<decimal> values) => _harmonic.Calculate(values);

        public decimal Median(IEnumerable<int> values) => _median.Calculate(values);
        public decimal Median(IEnumerable<decimal> values) => _median.Calculate(values);
    }
}
