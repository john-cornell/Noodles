using System.Collections.Generic;
using System.Linq;
using Noodles.Exceptions;
using Noodles.ML.Data.Stores;
using Noodles.ML.Data.Stores.Factories;

namespace Noodles.ML.Data
{
    public abstract class Projection<T>
    {
        List<string[]> _headers;
        public IDataStore<T> Data { get; private set; }

        public Projection(IDataStore<T> data)
        {
            Data = data;
        }

        public Projection(int columnCount, int initialRowCount, DataStoreType dataStoreType)
        {
            Data = DataStoreFactory<T>.CreateDataStore(dataStoreType, initialRowCount, columnCount);
        }

        public void Add(IEnumerable<IEnumerable<T>> data)
        {
            if (!data.Any()) return;

            AssertConsistentRowLength(data);
            AssertColumnCount(data.First());

            Data.Add(data);
        }

        public void Add(IEnumerable<T> row)
        {
            AssertColumnCount(row);

            Data.Add(row);
        }

        public void Add(params IEnumerable<T>[] data)
        {
            Data.Add(data);
        }

        private void AssertColumnCount(IEnumerable<T> row)
        {
            if (Data.ColumnCount > 0 && row.Count() != Data.ColumnCount) throw new IncorrectRowLengthException(row.Count(), Data.ColumnCount);
        }

        private static void AssertConsistentRowLength(IEnumerable<IEnumerable<T>> data)
        {
            if (data.Select(d => d.Count()).Distinct().Count() > 1) throw new InconsistentRowLengthException();
        }
    }
}
