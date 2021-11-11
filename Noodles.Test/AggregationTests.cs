using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.MeansCalculations;
using Noodles.Test.Utilities;

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
        public void WhenArithmeticMeanCalled_GivenDecimalNull_ShouldThrowArgumentNullException()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic((decimal[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenGeometricMeanCalled_GivenDecimalNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Geometric((decimal[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenHarmonicMeanCalled_GivenDecimalNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Harmonic((decimal[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenMedianCalled_GivenDecimalNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Median((decimal[])null));
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
            Assert.AreEqual(3.5m, Calculator.Means.Arithmetic(new int[] { 1, 2, 3, 4, 5, 6 }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(3.76435m, Math.Round(Calculator.Means.Geometric(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 5));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(2.9435m, Math.Round(Calculator.Means.Harmonic(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 5));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual((decimal)333 + ((decimal)1 / 3), Calculator.Means.Arithmetic(new int[] { 12, 97, 123, 401, 1275, 92 }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(13.477m, Math.Round(Calculator.Means.Geometric(new int[] { 15, 12, 13, 19, 10 }), 3));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(13.1733m, Math.Round(Calculator.Means.Harmonic(new int[] { 15, 12, 13, 19, 10 }), 4));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<int> ints = provider.GetRandomInts(50).ToList();

            decimal expected = BruteForceCalculateArithmeticMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(ints));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            decimal expected = BruteForceCalculateGeometricMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Geometric(ints));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            decimal expected = BruteForceCalculateHarmonicMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(ints));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDecimalEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(5.25m, Calculator.Means.Arithmetic(new decimal[] { 3.5m, 3.25m, 10.05m, 4.2m }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDecimalEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(4.681m, Math.Round(Calculator.Means.Geometric(new decimal[] { 3.5m, 3.25m, 10.05m, 4.2m }), 3));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDecimalEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(72.90905m, Math.Round(
                Calculator.Means.Geometric(new decimal[] { 97.521m, 52.6987m, 8.95m, 456.1154m, 98.2m }), 5));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDecimalEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(0.4967m, Math.Round(Calculator.Means.Harmonic(new decimal[] { 0.6m, 0.9m, 0.26m, 0.7m }), 4));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDecimalEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(32.6078m, Math.Round(
                Calculator.Means.Harmonic(new decimal[] { 97.521m, 52.6987m, 8.95m, 456.1154m, 98.2m }), 4));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenDecimalEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<decimal> decimals = provider.GetRandomDecimals(50).ToList();

            decimal expected = BruteForceCalculateGeometricMean(decimals);

            Assert.AreEqual(expected, Calculator.Means.Geometric(decimals));
        }

        //Testing with a more brute force algorithm than implemented in code
        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenDecimalEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<decimal> decimals = provider.GetRandomDecimals(50).ToList();

            decimal expected = BruteForceCalculateArithmeticMean(decimals);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(decimals));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenDecimalEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<decimal> decimals = provider.GetRandomDecimals(50).ToList();

            decimal expected = BruteForceCalculateHarmonicMean(decimals);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(decimals));
        }

        public decimal BruteForceCalculateArithmeticMean(IEnumerable<int> values)
        {
            return BruteForceCalculateArithmeticMean(values.Select(i => (decimal)i));
        }
        public decimal BruteForceCalculateArithmeticMean(IEnumerable<decimal> values)
        {
            decimal sum = 0;
            foreach (decimal value in values)
            {
                sum += (decimal)value;
            }

            return sum / (decimal)values.Count();
        }
        public decimal BruteForceCalculateGeometricMean(IEnumerable<int> values)
        {
            return BruteForceCalculateGeometricMean(values.Select(i => (decimal)i));
        }
        public decimal BruteForceCalculateGeometricMean(IEnumerable<decimal> values)
        {
            decimal product = 1;
            foreach (decimal value in values)
            {
                product *= (decimal)value;
            }

            return (decimal)Math.Pow((double)product, (1d / (double)values.Count()));
        }

        public decimal BruteForceCalculateHarmonicMean(IEnumerable<int> values)
        {
            return BruteForceCalculateHarmonicMean(values.Select(i => (decimal)i));
        }
        public decimal BruteForceCalculateHarmonicMean(IEnumerable<decimal> values)
        {
            decimal n = (decimal)values.Count();

            decimal sum = 0m;

            foreach (decimal m in values)
            {
                sum += (1m / m);
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
            List<int> values = new RandomProvider().GetRandomInts(100).ToList();
            Assert.IsTrue(Aggregation.Properties.Symmetry.Test(values, new ArithmeticMeanCalculator()));
        }

        [TestMethod]
        /// <summary>
        /// Not sure if positionally weighted can be counted as aggregation, but here just to test fail
        /// </summary>
        public void WhenSymmetryOfPositionalWeightedAggregationTested_ShouldNotPass()
        {
            List<int> values = new RandomProvider().GetRandomInts(5).ToList();
            Assert.IsFalse(Aggregation.Properties.Symmetry.Test(values, new PositionallyWeightedAggregation()));
        }

        [TestMethod]
        public void WhenTranslationInvarianceTestCalledFromAggregationStatic_ShouldNotBeNull()
        {
            Assert.IsNotNull(Aggregation.Properties.TranslationInvariance);
        }

        [TestMethod]
        public void WhenTranslationInvarianceOfArithmeticMeanTested_ShouldPass()
        {
            IEnumerable<int> values = new List<int> { 1, 2, 3, 4, 5 };// new RandomProvider().GetRandomInts(100);
            Assert.IsTrue(Aggregation.Properties.TranslationInvariance.Test(values, new ArithmeticMeanCalculator()));
        }

        [TestMethod]
        /// <summary>
        /// Not sure if positionally weighted can be counted as aggregation, but here just to test fail
        /// </summary>
        public void WhenTranslationInvarianceOfPositionalWeightedAggregationTested_ShouldNotPass()
        {
            IEnumerable<int> values = new RandomProvider().GetRandomInts(100);
            Assert.IsFalse(Aggregation.Properties.TranslationInvariance.Test(values, new PositionallyWeightedAggregation()));
        }

        #endregion
    }
}
