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
        public void WhenArithmeticMeanCalled_GivenfloatNull_ShouldThrowArgumentNullException()
        {
            Assert.AreEqual(0, Calculator.Means.Arithmetic((float[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenGeometricMeanCalled_GivenfloatNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Geometric((float[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenHarmonicMeanCalled_GivenfloatNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Harmonic((float[])null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenMedianCalled_GivenfloatNull_ShouldThrowArgumentException()
        {
            Assert.AreEqual(0, Calculator.Means.Median((float[])null));
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
            Assert.AreEqual((float)333 + ((float)1 / 3), Calculator.Means.Arithmetic(new int[] { 12, 97, 123, 401, 1275, 92 }));
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

            float expected = BruteForceCalculateArithmeticMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(ints));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            float expected = BruteForceCalculateGeometricMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Geometric(ints));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenIntEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();

            List<int> ints = provider.GetRandomInts(50).ToList();

            float expected = BruteForceCalculateHarmonicMean(ints);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(ints));
        }

        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenfloatEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(5.25, Calculator.Means.Arithmetic(new float[] { 3.5f, 3.25f, 10.05f, 4.2f }));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenfloatEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(4.681, Math.Round(Calculator.Means.Geometric(new float[] { 3.5f, 3.25f, 10.05f, 4.2f }), 3));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenfloatEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(72.90905, Math.Round(
                Calculator.Means.Geometric(new float[] { 97.521f, 52.6987f, 8.95f, 456.1154f, 98.2f }), 5));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenfloatEnumerableKnown_1_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(0.4967, Math.Round(Calculator.Means.Harmonic(new float[] { 0.6f, 0.9f, 0.26f, 0.7f }), 4));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenfloatEnumerableKnown_2_ShouldReturnCorrectAnswer()
        {
            Assert.AreEqual(32.6078, Math.Round(
                Calculator.Means.Harmonic(new float[] { 97.521f, 52.6987f, 8.95f, 456.1154f, 98.2f }), 4));
        }

        [TestMethod]
        public void WhenGeometricMeanCalled_GivenfloatEnumerableRandom_ShouldReturnCorrectAnswer()
        {
            RandomProvider provider = new RandomProvider();
            List<float> floats = provider.GetRandomfloats(50).ToList();

            float expected = BruteForceCalculateGeometricMean(floats);

            Assert.AreEqual(expected, Calculator.Means.Geometric(floats));
        }

        //Testing with a more brute force algorithm than implemented in code
        [TestMethod]
        public void WhenArithmeticMeanCalled_GivenfloatEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<float> floats = provider.GetRandomfloats(50).ToList();

            float expected = BruteForceCalculateArithmeticMean(floats);

            Assert.AreEqual(expected, Calculator.Means.Arithmetic(floats));
        }

        [TestMethod]
        public void WhenHarmonicMeanCalled_GivenfloatEnumerableRandom_ShouldReturnCorrectAnswer()
        {

            RandomProvider provider = new RandomProvider();
            List<float> floats = provider.GetRandomfloats(50).ToList();

            float expected = BruteForceCalculateHarmonicMean(floats);

            Assert.AreEqual(expected, Calculator.Means.Harmonic(floats));
        }

        public float BruteForceCalculateArithmeticMean(IEnumerable<int> values)
        {
            return BruteForceCalculateArithmeticMean(values.Select(i => (float)i));
        }
        public float BruteForceCalculateArithmeticMean(IEnumerable<float> values)
        {
            float sum = 0;
            foreach (float value in values)
            {
                sum += (float)value;
            }

            return sum / (float)values.Count();
        }
        public float BruteForceCalculateGeometricMean(IEnumerable<int> values)
        {
            return BruteForceCalculateGeometricMean(values.Select(i => (float)i));
        }
        public float BruteForceCalculateGeometricMean(IEnumerable<float> values)
        {
            float product = 1;
            foreach (float value in values)
            {
                product *= (float)value;
            }

            return MathF.Pow(product, (1f / (float)values.Count()));
        }

        public float BruteForceCalculateHarmonicMean(IEnumerable<int> values)
        {
            return BruteForceCalculateHarmonicMean(values.Select(i => (float)i));
        }
        public float BruteForceCalculateHarmonicMean(IEnumerable<float> values)
        {
            float n = (float)values.Count();

            float sum = 0f;

            foreach (float f in values)
            {
                sum += (1f / f);
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
            Assert.IsTrue(Aggregation.Properties.TranslationInvariance.Test(values, new PositionallyWeightedAggregation()));
        }

        #endregion
    }
}
