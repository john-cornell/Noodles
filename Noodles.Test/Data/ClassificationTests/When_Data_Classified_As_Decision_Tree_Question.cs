using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.ML.Classification.DecisionTree;
using Noodles.Test.Utilities;
using static Noodles.ML.Classification.DecisionTree.Question;

namespace Noodles.Test.Data.ClassificationTests
{
    [TestClass]
    public class When_Data_Classified_As_Decision_Tree_Question
    {
        readonly RandomProvider _random;
        readonly QuestionTypeClassifier _classifier;

        public When_Data_Classified_As_Decision_Tree_Question()
        {
            _random = new RandomProvider();

            _classifier = new QuestionTypeClassifier();
        }

        [TestMethod]
        public void Classifies_Labels_Correctly()
        {
            IEnumerable<string> labels = _random.GetRandomWords(1000);

            Assert.AreEqual(QuestionType.Labels, _classifier.ClassifyColumn(labels));
        }

        [TestMethod]
        public void Identifies_Labels_Correctly()
        {
            IEnumerable<object> labels = new object[]
            {
                "One",
                "One",
                "Two",
                "Two",
                "One",
                "One",
                "Three",
                "One",
                "One",
                "Three",
                "One",
                "One",
                "Four",
                "One",

            };

            DataTable table = new DataTable();
            table.Column[0] = labels;

            DecisionGeneratorContext context = new DecisionGeneratorContext(table, null, null);

            Assert.AreEqual(QuestionType.Labels, context.QuestionTypes[0]);
            Assert.AreEqual(1, context.CategoricalData.Count);
            Assert.AreEqual(4, context.CategoricalData[0].Count);
            Assert.IsTrue(context.CategoricalData[0].Contains("One"));
            Assert.IsTrue(context.CategoricalData[0].Contains("Two"));
            Assert.IsTrue(context.CategoricalData[0].Contains("Three"));
            Assert.IsTrue(context.CategoricalData[0].Contains("Four"));
        }

        [TestMethod]
        public void Identifies_Continuous_Correctly()
        {
            IEnumerable<decimal> data = _random.GetRandomDecimals(1000);

            Assert.AreEqual(QuestionType.Continuous, _classifier.ClassifyColumn(data.Select(d => (object)d)));
        }

        [TestMethod]
        public void Identifies_Continuous_Correctly_In_Context()
        {
            IEnumerable<decimal> data = _random.GetRandomDecimals(1000);

            DataTable table = new DataTable();
            table.Column[0] = data.Select(d => (object)d);

            DecisionGeneratorContext context = new DecisionGeneratorContext(table);
            Assert.AreEqual(QuestionType.Continuous, context.QuestionTypes[0]);
        }

        [TestMethod]
        public void Identifies_Continuous_Correctly_When_Ints_Greater_Than_Threshold()
        {
            IEnumerable<int> data = new int[]
            {
                1,2,3,4,5,6,7,8,9,10,11
            };


            Assert.AreEqual(QuestionType.Continuous, _classifier.ClassifyColumn(data.Select(d => (object)d), discreteCountThreshold: 10));
        }

        [TestMethod]
        public void Identifies_Continuous_Correctly_In_Context_When_Ints_Greater_Than_Threshold()
        {
            IEnumerable<int> data = new int[]
            {
                1,2,3,4,5,6,7,8,9,10,11
            };

            DataTable table = new DataTable();
            table.Column[0] = data.Select(d => (object)d);

            DecisionGeneratorContext context = new DecisionGeneratorContext(table);
            Assert.AreEqual(QuestionType.Continuous, context.QuestionTypes[0]);
        }

        [TestMethod]
        public void Identifies_Discrete_Correctly_When_Ints_Smaller_Or_Equal_To_Threshold()
        {
            int threshold = 15;

            for (int i = 1; i <= threshold; i++)
            {
                IEnumerable<int> data = Enumerable.Range(1, i);

                Assert.AreEqual(QuestionType.Discrete, _classifier.ClassifyColumn(data.Select(d => (object)d), discreteCountThreshold: threshold));
            }
        }

        [TestMethod]
        public void Identifies_Categorical_Numeric_Correctly()
        {
            int threshold = 15;

            for (int i = 1; i <= threshold; i++)
            {
                IEnumerable<int> data = Enumerable.Range(1, i);

                Assert.AreEqual(QuestionType.CategoricalNumeric, _classifier.ClassifyColumn(data.Select(d => (object)d), hint: QuestionType.CategoricalNumeric));
            }
        }
    }
}
