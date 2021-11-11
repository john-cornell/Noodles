using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Test.Utilities;
using Noodles.Utilities.Combinations;

namespace Noodles.Test.UtilityTests
{
    [TestClass]
    public class When_Index_Combination_Called
    {
        RandomProvider _randomProvider;

        [TestInitialize]
        public void Setup()
        {
            _randomProvider = new RandomProvider();
        }

        [TestMethod]
        public void Should_Return_Correct_Number_Of_Items()
        {
            IndexCombinationProvider combinations = new IndexCombinationProvider();

            for (int i = 1; i < 1000; i++)
            {
                int expected = (i * (i + 1)) / 2;
                Assert.AreEqual(expected, combinations.GetIndexPairCombinations(i).Count());
            }
        }

        [TestMethod]
        public void Should_Return_Distinct_Items()
        {
            IndexCombinationProvider combinations = new IndexCombinationProvider();

            IEnumerable<Tuple<int, int>> cList = combinations.GetIndexPairCombinations(1000);

            Assert.IsTrue(Enumerable.SequenceEqual(cList, cList.Distinct()));
        }

        [TestMethod]
        public void Should_Return_Tuples_ItemOne_Smaller_Than_ItemTwo()
        {
            IndexCombinationProvider combinations = new IndexCombinationProvider();

            IEnumerable<Tuple<int, int>> cList = combinations.GetIndexPairCombinations(1000);

            Assert.IsTrue(cList.Count(t => t.Item1 > t.Item2) == 0);
        }
    }
}
