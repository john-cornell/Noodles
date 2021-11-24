using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Data.Transformations;
using Noodles.Test.Utilities;

namespace Noodles.Test.Data.TransformationTests
{
    [TestClass]
    public class When_Column_Transformed
    {
        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Directly_should_transform_properly(DataStoreType dataStoreType)
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();

            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);
            List<bool> outcome = table.Column["Outcome"].Select(i => (double)i == 1d).ToList();

            table.TransformColumn("Outcome", transformer);

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column["Outcome"], outcome.Select(o => (object)o)));
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void To_another_should_transform_properly(DataStoreType dataStoreType)
        {
            NumericToBooleanTransformer transformer = new NumericToBooleanTransformer();

            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);

            List<double> original = table.Column["Outcome"].Select(o => (double)o).ToList();
            List<bool> outcome = table.Column["Outcome"].Select(i => (int)(double)i == 1).ToList();

            table.TransformToColumn("Outcome", "OutcomeBool", transformer);

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column["OutcomeBool"], outcome.Select(o => (object)o)));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column["Outcome"].Select(o => (double)o), original));
        }
    }
}
