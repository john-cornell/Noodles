using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Test.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.Test
{
    [TestClass]
    public class AggregationTests
    {
        [TestMethod]
        public void WhenArithmeticMeanCalled_ShouldNotFail()
        {
            bool exception = false;
            try
            {
                List<int> values = new List<int> { 2, 6, 4, 2, 12 };
            }
            catch
            {
                exception = true;
            }

            Assert.IsFalse(exception);
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDoubleNull_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic.Calculate((double[])null));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntNull_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic.Calculate((int[])null));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenEmptyEnumerable_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic.Calculate(new int[] { }));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(3.5, Calculator.Means.Arithmetic.Calculate(new int[] { 1, 2, 3, 4, 5, 6 }));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual((double)333 + ((double)1 / 3), Calculator.Means.Arithmetic.Calculate(new int[] { 12, 97, 123, 401, 1275, 92 }));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<int> ints = provider.GetRandomInts(50).ToList();

            double expected = BruteForceCalculateArithmeticMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic.Calculate(ints));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDoubleEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(5.25, Calculator.Means.Arithmetic.Calculate(new double[] { 3.5d, 3.25d, 10.05, 4.2 }));
        }
        
        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDoubleEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            
            RandomProvider provider = new RandomProvider();
            List<double> doubles = provider.GetRandomDoubles(5).ToList();

            double expected = BruteForceCalculateArithmeticMean(doubles);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic.Calculate(doubles));
        }

        //Testing with a more brute force algorithm than implemented in code
        public double BruteForceCalculateArithmeticMean(IEnumerable<int> values)
        {
            return BruteForceCalculateArithmeticMean(values.Select(i => (double)i));
        }
        public double BruteForceCalculateArithmeticMean(IEnumerable<double> values)
        {
            double sum = 0;
            foreach (int value in values)
            {
                sum += (double)value;
            }

            return sum / (double)values.Count();
        }
    }
}
