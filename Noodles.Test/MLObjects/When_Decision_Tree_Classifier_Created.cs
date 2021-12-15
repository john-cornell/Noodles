using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Exceptions;
using Noodles.ML.Classification.DecisionTree;
using Noodles.Test.Utilities;

namespace Noodles.Test.MLObjects
{
    [TestClass]
    public class When_Decision_Tree_Classifier_Created
    {
        RandomProvider _random;

        [TestInitialize]
        public void Initialize()
        {
            _random = new RandomProvider();
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_bool_label(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<string> column2 = _random.GetRandomWords(4322).ToList();
            List<string> column3 = _random.GetRandomWords(432).ToList();
            List<string> column4 = _random.GetRandomWords(62).ToList();
            List<bool> column5 = _random.GetRandomBools(4322).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();
            table.Column[5] = column5.Cast<object>();

            DecisionTreeClassifier classifier = new DecisionTreeClassifier(table);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_int_label(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<string> column2 = _random.GetRandomWords(4322).ToList();
            List<string> column3 = _random.GetRandomWords(432).ToList();
            List<string> column4 = _random.GetRandomWords(62).ToList();
            List<int> column5 = _random.GetRandomInts(4322, 0, 2).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();
            table.Column[5] = column5.Cast<object>();

            DecisionTreeClassifier classifier = new DecisionTreeClassifier(table);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_int_label_override_position(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<int> column2 = _random.GetRandomInts(4322, 0, 2).ToList();
            List<string> column3 = _random.GetRandomWords(4322).ToList();
            List<string> column4 = _random.GetRandomWords(432).ToList();
            List<string> column5 = _random.GetRandomWords(62).ToList();


            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();
            table.Column[5] = column5.Cast<object>();

            DecisionTreeClassifier classifier = new DecisionTreeClassifier(table, 2);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_bool_label_override_position(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<bool> column2 = _random.GetRandomBools(4322).ToList();
            List<string> column3 = _random.GetRandomWords(4322).ToList();
            List<string> column4 = _random.GetRandomWords(432).ToList();
            List<string> column5 = _random.GetRandomWords(62).ToList();


            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();
            table.Column[5] = column5.Cast<object>();

            DecisionTreeClassifier classifier = new DecisionTreeClassifier(table, 2);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_on_label_if_not_all_records_covered(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<bool> column2 = _random.GetRandomBools(4321).ToList();
            List<string> column3 = _random.GetRandomWords(4322).ToList();
            List<string> column4 = _random.GetRandomWords(432).ToList();
            List<string> column5 = _random.GetRandomWords(62).ToList();


            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();
            table.Column[5] = column5.Cast<object>();

            DecisionTreeClassifier classifier = new DecisionTreeClassifier(table, 2);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_diabetes_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);
            _ = new DecisionTreeClassifier(table);

            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_on_incorrect_label_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);
            _ = new DecisionTreeClassifier(table, 4);
        }
    }
}
