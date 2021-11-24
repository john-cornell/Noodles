using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Data.Validations;
using Noodles.Data.Validations.Context;
using Noodles.Exceptions;
using Noodles.Test.Utilities;

namespace Noodles.Test.Data
{
    [TestClass]
    public class When_DataTable_Validated
    {
        RandomProvider _random;
        Validator _validator;

        [TestInitialize]
        public void Initialize()
        {
            _random = new RandomProvider();
            _validator = new Validator();
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_validation_when_all_rows_not_numeric(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<string> column2 = _random.GetRandomWords(51233).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(321).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllNumeric);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_validation_when_single_item_not_numeric(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<int> column2 = _random.GetRandomInts(4322).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(321).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            table.Data[1234, 2] = "Hello";

            Assert.AreEqual("Hello", table.Data[1234, 2]);

            _validator.Validate(table, ValidationType.AllNumeric);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_pass_validation_when_all_numeric_on_all_numeric_validation(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<int> column2 = _random.GetRandomInts(4322).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(321).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllNumeric);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_validation_when_all_numeric_different_types_all_data_distinct_validation(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<int> column2 = _random.GetRandomInts(4322).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(321).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllDataDistinctType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_fail_validation_when_all_ints_all_data_distinct_validation(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<int> column2 = _random.GetRandomInts(4322).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<int> column4 = new List<int>
            {
                1,6,3,7,3234,124,7,4,324523,1,6,54643
            };

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllDataDistinctType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_fail_validation_when_all_decimals_all_data_distinct_validation(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<decimal> column0 = _random.GetRandomDecimals(100).ToList();
            List<decimal> column1 = _random.GetRandomDecimals(2243).Select(i => i * 10).ToList();
            List<decimal> column2 = _random.GetRandomDecimals(4322).ToList();
            List<decimal> column3 = _random.GetRandomDecimals(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(62).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllDataDistinctType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_fail_validation_when_all_strings_all_data_distinct_validation(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<string> column0 = _random.GetRandomDecimals(100).Select(d => d.ToString()).ToList();
            List<string> column1 = _random.GetRandomInts(100).Select(i => i.ToString()).ToList();
            List<string> column2 = _random.GetRandomWords(4322).ToList();
            List<string> column3 = _random.GetRandomWords(432).ToList();
            List<string> column4 = _random.GetRandomWords(62).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));

            _validator.Validate(table, ValidationType.AllDataDistinctType);
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

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { });
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

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { });
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

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { OverrideLabelColumn = 2 });
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

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { OverrideLabelColumn = 2 });
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

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { OverrideLabelColumn = 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(NullValidationContextException))]
        public void Should_fail_validation_when_context_required_but_not_given()
        {
            Validation_DecisionTree validator = new Validation_DecisionTree();
            validator.Validate(new DataTable(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectValidationContextException))]
        public void Should_fail_validation_when_incorrect_context_given()
        {
            Validation_DecisionTree validator = new Validation_DecisionTree();
            validator.Validate(new DataTable(), new Unknown_Context());
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_on_diabetes_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);

            _validator.Validate(table, ValidationType.DecisionTree, new DecisionTreeValidationContext() { });

            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ValidationException))]
        public void Should_fail_on_incorrect_label_data(DataStoreType dataStoreType)
        {
            Validation_DecisionTree validator = new Validation_DecisionTree();
            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);

            validator.Validate(table, new DecisionTreeValidationContext() { OverrideLabelColumn = 4 });
        }
    }

    class Unknown_Context : ValidationContext
    {
        public Unknown_Context() : base(ValidationType.Unknown)
        {

        }
    }

}
