using System.Collections.Generic;
using Noodles.Data.Indexers;

namespace Noodles.Data
{
    public interface IDataStore<T>
    {
        int RowCount { get; }
        int ColumnCount { get; set; }

        void Add(IEnumerable<IEnumerable<T>> data);
        void Add(IEnumerable<T> row);
        void Add(params IEnumerable<T>[] data);

        T this[int row, int column] { get; set; }

        IIndexer<T, IEnumerable<T>> Column { get; }
        IIndexer<T, IEnumerable<T>> Row { get; }
    }
}
