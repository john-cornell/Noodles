using System.Collections.Generic;

namespace Noodles.ML.Data
{
    public interface IDataStore<T>
    {
        int RowCount { get; }
        int ColumnCount { get; set; }

        public void Add(IEnumerable<IEnumerable<T>> data);
        public void Add(IEnumerable<T> row);
        public void Add(params IEnumerable<T>[] data);

        T this[int row, int column] { get; set; }
    }
}
