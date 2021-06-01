using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.MeansCalculations;
using Noodles.Test.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.Test
{
    [TestClass]
    public class AggregationTests
    {
        #region Means Calculations
        [TestMethod]
        public void WhenArithmeticMeanCalled_ShouldNotFail()
        {
            bool exception = false;
            try
            {
                List<int> values = new List<int> { 2, 6, 4, 2, 12 };
                Calculator.Means.Arithmetic(values);
            }
            catch
            {
                exception = true;
            }

            Assert.IsFalse(exception);
        }

        [TestMethod]
        public void WhenGeometicMeanCalled_ShouldNotFail()
        {
            bool exception = false;
            try
            {
                List<int> values = new List<int> { 2, 6, 4, 2, 12 };
                Calculator.Means.Geometric(values);
            }
            catch
            {
                exception = true;
            }

            Assert.IsFalse(exception);
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_ShouldNotFail()
        {
            bool exception = false;
            try
            {
                List<int> values = new List<int> { 2, 6, 4, 2, 12 };
                Calculator.Means.Harmonic(values);
            }
            catch
            {
                exception = true;
            }

            Assert.IsFalse(exception);
        }

        [TestMethod]
        public void WhenMedianCalled_ShouldNotFail()
        {
            bool exception = false;
            try
            {
                List<int> values = new List<int> { 2, 6, 4, 2, 12 };
                Calculator.Means.Median(values);
            }
            catch
            {
                exception = true;
            }

            Assert.IsFalse(exception);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenArithmeticMeanCalled_GivenDoubleNull_ShouldThrowArgumentNullException()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic((double[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenGeometricMeanCalled_GivenDoubleNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Geometric((double[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenHarmonicMeanCalled_GivenDoubleNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Harmonic((double[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenMedianCalled_GivenDoubleNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Median((double[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenArithmeticMeanCalled_GivenIntNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic((int[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenGeometricMeanCalled_GivenIntNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Geometric((int[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenHarmonicMeanCalled_GivenIntNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Harmonic((int[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenMedianCalled_GivenIntNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Median((int[])null));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenEmptyEnumerable_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic(new int[] { }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenEmptyEnumerable_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Geometric(new int[] { }));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenEmptyEnumerable_ShouldReturnZero()
        {
            Assert.AreEqual(0, Calculator.Means.Harmonic(new int[] { }));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(3.5, Calculator.Means.Arithmetic(new int[] { 1, 2, 3, 4, 5, 6 }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(3.76435, Math.Round(Calculator.Means.Geometric(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 5));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(2.9435, Math.Round(Calculator.Means.Harmonic(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 5));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual((double)333 + ((double)1 / 3), Calculator.Means.Arithmetic(new int[] { 12, 97, 123, 401, 1275, 92 }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(13.477, Math.Round(Calculator.Means.Geometric(new int[] { 15, 12, 13, 19, 10 }), 3));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(13.1733, Calculator.Means.Harmonic(new int[] { 15, 12, 13, 19, 10 }), 3);
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<int> ints = provider.GetRandomInts(50).ToList();

            double expected = BruteForceCalculateArithmeticMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(ints));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            double expected = BruteForceCalculateGeometricMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Geometric(ints));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            double expected = BruteForceCalculateHarmonicMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(ints));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDoubleEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(5.25, Calculator.Means.Arithmetic(new double[] { 3.5d, 3.25d, 10.05, 4.2 }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDoubleEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(4.681, Math.Round(Calculator.Means.Geometric(new double[] { 3.5d, 3.25d, 10.05, 4.2 }), 3));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDoubleEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(72.90905, Math.Round(
                Calculator.Means.Geometric(new double[] { 97.521, 52.6987, 8.95, 456.1154, 98.2 }), 5));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDoubleEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(0.4967, Math.Round(Calculator.Means.Harmonic(new double[] { 0.6, 0.9, 0.26, 0.7 }), 4));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDoubleEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(32.6078, Math.Round(
                Calculator.Means.Harmonic(new double[] { 97.521, 52.6987, 8.95, 456.1154, 98.2 }), 4));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDoubleEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<double> doubles = provider.GetRandomDoubles(50).ToList();

            double expected = BruteForceCalculateGeometricMean(doubles);

            Assert.AreEqual(expected, Calculator.Means.Geometric(doubles));
        }

        //Testing with a more brute force algorithm than implemented in code
        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDoubleEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<double> doubles = provider.GetRandomDoubles(50).ToList();

            double expected = BruteForceCalculateArithmeticMean(doubles);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(doubles));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDoubleEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<double> doubles = provider.GetRandomDoubles(50).ToList();

            double expected = BruteForceCalculateHarmonicMean(doubles);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(doubles));
        }

        public double BruteForceCalculateArithmeticMean(IEnumerable<int> values)
        {
            return BruteForceCalculateArithmeticMean(values.Select(i => (double)i));
        }
        public double BruteForceCalculateArithmeticMean(IEnumerable<double> values)
        {
            double sum = 0;
            foreach (double value in values)
            {
                sum += (double)value;
            }

            return sum / (double)values.Count();
        }
        public double BruteForceCalculateGeometricMean(IEnumerable<int> values)
        {
            return BruteForceCalculateGeometricMean(values.Select(i => (double)i));
        }
        public double BruteForceCalculateGeometricMean(IEnumerable<double> values)
        {
            double product = 1;
            foreach (double value in values)
            {
                product *= (double)value;
            }

            return Math.Pow(product, (1d / (double)values.Count()));
        }

        public double BruteForceCalculateHarmonicMean(IEnumerable<int> values)
        {
            return BruteForceCalculateHarmonicMean(values.Select(i => (double)i));
        }
        public double BruteForceCalculateHarmonicMean(IEnumerable<double> values)
        {
            double n = (double)values.Count();

            double sum = 0d;

            foreach (double d in values)
            {
                sum += (1d / d);
            }

            return n / sum;
        }
        #endregion

        #region Aggregation Properties

        [TestMethod]
        public void WhenMeansCalledFromAggregationStatic_ShouldNotBeNull()
        {
            Assert.IsNotNull(Aggregation.Means);
        }

        [TestMethod]
        public void WhenPropertiesCalledFromAggregationStatic_ShouldNotBeNull()
        {
            Assert.IsNotNull(Aggregation.Properties);
        }


        [TestMethod]
        public void WhenSymmetryTestCalledFromAggregationStatic_ShouldNotBeNull()
        {
            Assert.IsNotNull(Aggregation.Properties.Symmetry);
        }



        [TestMethod]
        public void WhenSymmetryOfArithmeticMeanTested_ShouldPass()
        {
            IEnumerable<int> values = new RandomProvider().GetRandomInts(100);
            Assert.IsTrue(Aggregation.Properties.Symmetry.Test(values, new ArithmeticMeanCalculator()));
        }

        [TestMethod]
        /// <summary>
        /// Not sure if positionally weighted can be counted as aggregation, but here just to test fail
        /// </summary>
        public void WhenSymmetryOfPositionalWeightedAggregationTested_ShouldNotPass()
        {
            IEnumerable<int> values = new RandomProvider().GetRandomInts(100);
            Assert.IsTrue(Aggregation.Properties.Symmetry.Test(values, new PositionallyWeightedAggregation()));
        }

        #endregion
    }
}
