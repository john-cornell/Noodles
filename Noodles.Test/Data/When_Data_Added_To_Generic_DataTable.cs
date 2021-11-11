using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Test.Utilities;

namespace Noodles.Test
{
    [TestClass]
    public class When_Data_Added_To_Generic_DataTable
    {
        RandomProvider _random;
        DataProvider _data;

        [TestInitialize]
        public void Initialize()
        {
            _random = new RandomProvider();
            _data = new DataProvider();
        }

        [TestMethod]
        public void Should_Accept_Mixed_Data()
        {
            List<List<object>> data = _data.GetObjectData(20, 100, (i) => i % 10 != 0);
            DataTable dataTable = new DataTable();
            dataTable.Add(data);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Should_Return_Typed_Data()
        {
            List<List<object>> data = _data.GetObjectData(20, 100, (i) => i % 10 != 0);
            DataTable dataTable = new DataTable();
            dataTable.Add(data);

            for (int i = 0; i < dataTable.ColumnCount; i++)
            {
                if (i % 10 == 0)
                {
                    IEnumerable<string> columnStringData = dataTable.GetColumn<string>(i);
                    Assert.IsTrue(columnStringData.All(d => d is string));
                }
                else
                {
                    IEnumerable<decimal> columnDecimalData = dataTable.GetColumn<decimal>(i);
                    Assert.IsTrue(columnDecimalData.All(d => d is decimal));
                }
            }
        }
    }
}
