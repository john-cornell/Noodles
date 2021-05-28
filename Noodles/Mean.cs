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

        public double Arithmetic(IEnumerable<int> values) => _arithmetic.Calculate(values);
        public double Arithmetic(IEnumerable<double> values) => _arithmetic.Calculate(values);

        public double Geometric(IEnumerable<int> values) => _geometric.Calculate(values);
        public double Geometric(IEnumerable<double> values) => _geometric.Calculate(values);

        public double Harmonic(IEnumerable<int> values) => _harmonic.Calculate(values);
        public double Harmonic(IEnumerable<double> values) => _harmonic.Calculate(values);

        public double Median(IEnumerable<int> values) => _median.Calculate(values);
        public double Median(IEnumerable<double> values) => _median.Calculate(values);
    }
}
