using Noodles.MeansCalculations;
using System;
using System.Collections.Generic;

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

        public float Arithmetic(IEnumerable<int> values) => _arithmetic.Calculate(values);
        public float Arithmetic(IEnumerable<float> values) => _arithmetic.Calculate(values);

        public float Geometric(IEnumerable<int> values) => _geometric.Calculate(values);
        public float Geometric(IEnumerable<float> values) => _geometric.Calculate(values);

        public float Harmonic(IEnumerable<int> values) => _harmonic.Calculate(values);
        public float Harmonic(IEnumerable<float> values) => _harmonic.Calculate(values);

        public float Median(IEnumerable<int> values) => _median.Calculate(values);
        public float Median(IEnumerable<float> values) => _median.Calculate(values);
    }
}
