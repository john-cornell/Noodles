using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Indexers;
using Noodles.Exceptions;
using Noodles.Extensions;

namespace Noodles.Data.Stores
{
    public class SingleArrayDataStore<T> : IDataStore<T>
    {
        int _dataLength = 0;
        int _initialRowCount = 0;
        T[] _data;

        int _allocatedRowSpace;
        int _columnCount;

        public SingleArrayDataStore(int columnCount, int initialRowCount)
        {
            ColumnCount = columnCount;
            _initialRowCount = initialRowCount;

            if (ColumnCount > 0) InitializeData();
            _allocatedRowSpace = initialRowCount;

            Row = new SingleArrayRowDataIndexer<T>(
                this,
                (index) => _data[index],
                (index, value) => _data[index] = value);
        }

        private void InitializeData()
        {
            _data = new T[ColumnCount * _initialRowCount];
        }

        public int ColumnCount
        {
            get { return _columnCount; }
            set
            {
                if (ColumnCount > 0) throw new ImmutabilityException($"Column Count is {ColumnCount} and may not be changed");
                if (value < 0) throw new InvalidValueException("Column Count cannot be set to a negative number");

                _columnCount = value;
            }
        }

        public int RowCount => _dataLength == 0 ? 0 : _dataLength / ColumnCount;

        public void Add(IEnumerable<IEnumerable<T>> data)
        {
            foreach (IEnumerable<T> row in data) Add(row);
        }

        public void Add(params IEnumerable<T>[] data)
        {
            data.ForEach(row => Add(row));
        }

        public void Add(IEnumerable<T> row)
        {
            if (row == null || !row.Any()) return;

            if (ColumnCount == 0)
            {
                ColumnCount = row.Count();
                InitializeData();
            }

            T[] array = row.ToArray();
            Array.Copy(array, 0, _data, _dataLength, array.Length);
            _dataLength += array.Length;
        }

        public T this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row >= RowCount || column >= ColumnCount) throw new IndexOutOfRangeException();

                return _data[((row * ColumnCount)) + column];
            }
            set
            {
                _data[((row * ColumnCount)) + column] = value;
            }
        }

        public IIndexer<T, IEnumerable<T>> Row { get; private set; }

        public IIndexer<T, IEnumerable<T>> Column { get; private set; }
    }
}