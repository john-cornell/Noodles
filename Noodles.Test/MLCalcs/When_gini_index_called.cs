using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.ML.Calculations;

namespace Noodles.Test.MLCalcs
{
    [TestClass]
    public class When_gini_index_called
    {
        [TestMethod]
        public void Should_return_correct_value_for_impurity()
        {
            Gini gini = new Gini();

            Assert.AreEqual(0.375m, gini.CalculateImpurity(1, 3));
            Assert.AreEqual((1m / 9m) * 4m, gini.CalculateImpurity(2, 1));
        }

        [TestMethod]
        public void With_node_should_return_correct_value_for_impurity()
        {
            Gini gini = new Gini();

            Assert.AreEqual(0.375m, gini.CalculateImpurity(new GiniNode(1, 3)));
            Assert.AreEqual((1m / 9m) * 4m, gini.CalculateImpurity(new GiniNode(2, 1)));
        }
        [TestMethod]
        public void Total_weighted_impurity_should_be_correct()
        {
            Gini gini = new Gini();

            Assert.AreEqual(0.405m, Math.Round(gini.CalculateTotalWeightedImpurity(
                new System.Tuple<GiniNode, GiniNode>(new GiniNode(1, 3), new GiniNode(2, 1))), 3, MidpointRounding.AwayFromZero));

            Assert.AreEqual(0.214m, Math.Round(gini.CalculateTotalWeightedImpurity(
                new System.Tuple<GiniNode, GiniNode>(new GiniNode(1, 3), new GiniNode(0, 3))), 3, MidpointRounding.AwayFromZero));
        }
    }
}
