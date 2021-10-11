using System;
using System.Collections;
using System.Collections.Generic;

namespace Noodles.Data.Projections
{
    public class DataRow<T> : Projection<T>, IEnumerable<T>
    {
        public int RowIndex { get; private set; }

        public DataRow(Projection<T> data, int rowIndex) : this(data.Data, rowIndex) { }

        public DataRow(IDataStore<T> data, int rowIndex) : base(data)
        {
            if (rowIndex < 0 || rowIndex >= data.RowCount) throw new IndexOutOfRangeException();

            RowIndex = rowIndex;
        }

        public IEnumerator<T> GetEnumerator() => Data.Row[RowIndex].GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
