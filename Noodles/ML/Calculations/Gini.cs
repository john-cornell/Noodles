using System;

namespace Noodles.ML.Calculations
{
    public class Gini
    {
        public decimal CalculateImpurity(int positive, int negative)
        {
            int total = positive + negative;

            decimal positiveProbability = (decimal)positive / (decimal)total;
            decimal negativeProbability = (decimal)negative / (decimal)total;

            decimal pSqr = positiveProbability * positiveProbability;
            decimal nSqr = negativeProbability * negativeProbability;

            return 1m - pSqr - nSqr;
        }

        public decimal CalculateImpurity(GiniNode node) => CalculateImpurity(node.Positive, node.Negative);

        public decimal CalculateTotalWeightedImpurity(Tuple<GiniNode, GiniNode> nodes)
        {
            decimal node1Impurity = CalculateImpurity(nodes.Item1);
            decimal node2Impurity = CalculateImpurity(nodes.Item2);

            decimal node1WeightedAverage =
                (
                    (decimal)nodes.Item1.Total / ((decimal)nodes.Item1.Total + (decimal)nodes.Item2.Total)
                ) * node1Impurity;

            decimal node2WeightedAverage =
                (
                    (decimal)nodes.Item2.Total / ((decimal)nodes.Item1.Total + (decimal)nodes.Item2.Total)
                ) * node2Impurity;

            return node1WeightedAverage + node2WeightedAverage;
        }
    }

    public class GiniNode
    {
        public GiniNode(int positive, int negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public int Positive { get; set; }
        public int Negative { get; set; }
        public int Total => Positive + Negative;
    }

}
