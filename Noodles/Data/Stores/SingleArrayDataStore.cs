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

        decimal _growthPercentage = 1.5m;

        int _columnCount;

        public SingleArrayDataStore(int columnCount, int initialRowCount)
        {
            ColumnCount = columnCount;
            _initialRowCount = initialRowCount;

            if (ColumnCount > 0) InitializeData();

            Row = new SingleArrayRowDataIndexer<T>(
                this,
                (index) => _data[index],
                (index, value) => _data[index] = value);

            Column = new SingleArrayColumnDataIndexer<T>(
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

        public int RowCount => _dataLength == 0 ? 0 : ((_dataLength) / ColumnCount);

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
            int newDataLength = _dataLength + array.Length;

            if (newDataLength > _data.Length)
            {
                Grow(minimumGrowth: newDataLength);//already handles position != slot count problem, in Grow call below, so no need to +1
            }

            Array.Copy(array, 0, _data, _dataLength, array.Length);

            _dataLength = newDataLength;
        }

        private void Grow(int minimumGrowth)
        {
            T[] newData = GenerateEmptyDataStore(minimumGrowth);

            Array.Copy(_data, 0, newData, 0, _data.Length);
            _data = newData;
        }

        private T[] GenerateEmptyDataStore(int minimumGrowth)
        {
            return new T[
                            Math.Max(
                                ExpandToNextRowSize(minimumGrowth),
                                ExpandToNextRowSize((int)((_data.Length) * _growthPercentage))
                                )];
        }

        //Account for whole row if minimum growth at part of row only, so Row Count isn't mucked up for incomplete rows
        private int ExpandToNextRowSize(int minimumGrowth)
        {
            int mod = ColumnCount == 0 ? minimumGrowth : minimumGrowth % ColumnCount;

            return minimumGrowth + (ColumnCount - mod);
        }

        void IDataStore<T>.ExpandToColumn(int requiredColumnIndex, int minRowSize)
        {
            int column = requiredColumnIndex + 1;//column input is index, so 0 based, we want actual number

            try
            {
                if (_data == null)
                {
                    _initialRowCount = minRowSize;
                    _columnCount = column;
                    InitializeData();

                    return;
                }

                int currentColumnCount = ColumnCount;
                int rowSize = Math.Max(minRowSize, RowCount);

                int minimumSize = Math.Max(column, column * rowSize);

                T[] nextDataStore = GenerateEmptyDataStore(minimumSize);

                int index = 0;
                int columnIdx = 0;

                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        nextDataStore[(i * column) + j] = this[i, j];
                    }
                }

                _dataLength = RowCount * column;
                _data = nextDataStore;
            }
            finally
            {
                _columnCount = column;
            }
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
                int position = ((row * ColumnCount)) + column;

                if (position >= _data.Length)
                {
                    Grow(minimumGrowth: position + 1);//zero based indexing means position n requires n + 1 slots, e.g. position 0 needs 1 slot
                }

                _data[position] = value;

                if (position >= _dataLength)//data was inserted after current _datalength, so expand
                {
                    _dataLength = ExpandToNextRowSize(position);//Growth should have ensured this position is valid
                }
            }
        }

        public IIndexer<T, IEnumerable<T>> Row { get; private set; }

        public IIndexer<T, IEnumerable<T>> Column { get; private set; }
    }
}