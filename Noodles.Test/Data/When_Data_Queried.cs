using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Test.ExtensionTests;

namespace Noodles.Test.Data
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class When_Data_Queried
    {
        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_return_correct_select_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<List<object>> data = new List<List<object>>
            {
                new List<object> { 1, 3, "CCC" },
                new List<object> { 2, 1, "AAA" },
                new List<object> { 3, 2, "BBB" }
            };

            table.Add(data);
            table.Headers = new string[] { "Id", "Number", "Letters" };

            List<IEnumerable<object>> returned =
                table.Rows().Where(r => r.First().To<int>() % 2 == 1).ToList();

            var rows = returned.Select(r => new
            {
                Id = Convert.ToInt32(r.First()),
                Number = Convert.ToInt32(r.ElementAt(1)),
                Text = r.Last()
            });

            Assert.AreEqual(2, rows.Count());
            Assert.AreEqual(0, rows.Select(r => r.Id).Except(new int[] { 1, 3 }).Count());
            Assert.AreEqual(0, new int[] { 1, 3 }.Except(rows.Select(r => r.Id)).Count());
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Inbuilt_typeless_where_should_return_correct_select_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<List<object>> data = new List<List<object>>
            {
                new List<object> { 1, 3, "CCC" },
                new List<object> { 2, 1, "AAA" },
                new List<object> { 3, 2, "BBB" }
            };

            table.Add(data);
            table.Headers = new string[] { "Id", "Number", "Letters" };

            List<IEnumerable<object>> returned =
                table.Where(r => r.Skip(1).First().To<int>() % 2 == 1).ToList();

            var rows = returned.Select(r => new
            {
                Id = Convert.ToInt32(r.First()),
                Number = Convert.ToInt32(r.ElementAt(1)),
                Text = r.Last()
            });

            Assert.AreEqual(2, rows.Count());
            Assert.AreEqual(0, rows.Select(r => r.Id).Except(new int[] { 1, 2 }).Count());
            Assert.AreEqual(0, new int[] { 1, 2 }.Except(rows.Select(r => r.Id)).Count());
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Inbuilt_typed_where_should_return_correct_select_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<List<object>> data = new List<List<object>>
            {
                new List<object> { 1, 3, "CCC" },
                new List<object> { 2, 1, "AAA" },
                new List<object> { 3, 2, "BBB" }
            };

            table.Add(data);
            table.Headers = new string[] { "Id", "Number", "Letters" };

            static TestData dataSelector(IEnumerable<object> ienum)
            {
                return new TestData
                {
                    Id = Convert.ToInt32(ienum.First()),
                    Number = Convert.ToInt32(ienum.Skip(1).First()),
                    Text = ienum.Skip(2).First().ToString()
                };

            }

            List<TestData> rows = table.Where(dataSelector, r => r.Text.StartsWith("A") || r.Text.StartsWith("C")).ToList();

            Assert.AreEqual(2, rows.Count());
            Assert.AreEqual(0, rows.Select(r => r.Id).Except(new int[] { 1, 2 }).Count());
            Assert.AreEqual(0, new int[] { 1, 2 }.Except(rows.Select(r => r.Id)).Count());
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Inbuilt_select_should_return_data(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<List<object>> data = new List<List<object>>
            {
                new List<object> { 1, 3, "CCC" },
                new List<object> { 2, 1, "AAA" },
                new List<object> { 3, 2, "BBB" }
            };

            table.Add(data);
            table.Headers = new string[] { "Id", "Number", "Letters" };

            static TestData dataSelector(IEnumerable<object> ienum)
            {
                return new TestData
                {
                    Id = Convert.ToInt32(ienum.First()),
                    Number = Convert.ToInt32(ienum.Skip(1).First()),
                    Text = ienum.Skip(2).First().ToString()
                };

            }

            List<TestData> rows = table.Select(dataSelector).OrderBy(d => d.Number).ToList();

            Assert.AreEqual(3, rows.Count());
            Assert.AreEqual(2, rows[0].Id);
            Assert.AreEqual(3, rows[1].Id);
            Assert.AreEqual(1, rows[2].Id);
        }
    }

    public class TestData
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

}
