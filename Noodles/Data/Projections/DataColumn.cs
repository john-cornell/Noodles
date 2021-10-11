using System;
using System.Collections;
using System.Collections.Generic;

namespace Noodles.Data.Projections
{
    public class DataColumn<T> : Projection<T>, IEnumerable<T>
    {
        public int ColumnIndex { get; private set; }

        public DataColumn(Projection<T> data, int columnIndex) : this(data.Data, columnIndex) { }

        public DataColumn(IDataStore<T> data, int columnIndex) : base(data)
        {
            if (columnIndex < 0 || columnIndex >= data.ColumnCount) throw new IndexOutOfRangeException();

            ColumnIndex = columnIndex;
        }

        public IEnumerator<T> GetEnumerator() => Data.Column[ColumnIndex].GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
