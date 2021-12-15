using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.Data.Indexers
{
    public class SingleArrayRowDataIndexer<T> : IIndexer<T, IEnumerable<T>>
    {
        readonly IDataStore<T> _data;
        readonly Func<int, T> _directDataAccessor;
        readonly Action<int, T> _directDataMutator;

        public SingleArrayRowDataIndexer(IDataStore<T> data, Func<int, T> directDataAccessor, Action<int, T> directDataMutator)
        {
            _data = data;
            _directDataAccessor = directDataAccessor;
            _directDataMutator = directDataMutator;
        }
        public IEnumerable<T> this[int index]
        {
            get
            {
                int rowStart = index * _data.ColumnCount;

                for (int i = 0; i < _data.ColumnCount; i++) { yield return _directDataAccessor(rowStart + i); }
            }
            set
            {
                int rowStart = index * _data.ColumnCount;

                for (int i = 0; i < _data.ColumnCount; i++) { _directDataMutator(rowStart + i, value.ElementAt(i)); }
            }
        }
    }
}
