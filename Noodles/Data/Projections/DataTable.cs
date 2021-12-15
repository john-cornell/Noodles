using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Indexers;
using Noodles.Data.Selectors;
using Noodles.Data.Stores;
using Noodles.Data.Transformations;
using Noodles.Exceptions;

namespace Noodles.Data.Projections
{
    public class DataTable : DataTable<object>
    {
        public DataTable() : this(0)
        {
            Row = new DataRowIndexer<object>(Data);
        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            IEnumerable<string> headers = null,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, headers: headers, dataStoreType: dataStoreType)
        {

        }

        public DataTable(string url, bool firstRowIsHeader = true, DataStoreType dataStoreType = DataStoreType.SingleArray, bool testForNumeric = true) : base(0, dataStoreType: dataStoreType)
        {
            DataTableUrlLoader.LoadData(this, url, firstRowIsHeader, testForNumeric);
        }

        public DataTable(IDataStore<object> data) : base(data) { }

        public IEnumerable<T> GetColumn<T>(int index) => Column[index].Cast<T>();
        public IEnumerable<T> GetRow<T>(int index) => Row[index].Cast<T>();

        public IEnumerable<IEnumerable<object>> Rows() => Rows<object>();
        public IEnumerable<IEnumerable<object>> Columns() => Columns<object>();

        public IEnumerable<IEnumerable<T>> Rows<T>()
        {
            for (int i = 0; i < RowCount; i++) yield return GetRow<T>(i).Select(datum => datum);
        }

        public void TransformToColumn<TInput, TOutput>(string sourceColumn, string destinationColumn, BaseTransformation<TInput, TOutput> transformer)
        {
            Column[destinationColumn] = Column[sourceColumn].Select(d => (object)transformer.ObjectTransform(d));
        }

        public IEnumerable<IEnumerable<T>> Columns<T>()
        {
            for (int i = 0; i < ColumnCount; i++) yield return GetColumn<T>(i);
        }

        public void TransformColumn<TInput, TOutput>(string columnName, BaseTransformation<TInput, TOutput> transformer)
        {
            TransformColumn(ColumnSelector.GetColumnIndex(columnName), transformer);
        }

        public void TransformColumn<TInput, TOutput>(int index, BaseTransformation<TInput, TOutput> transformer)
        {
            Column[index] = Column[index].Select(i => (object)transformer.ObjectTransform(i));
        }

        public void TransformRow<TInput, TOutput>(int index, BaseTransformation<TInput, TOutput> transformer)
        {
            Row[index] = Row[index].Select(i => (object)transformer.ObjectTransform(i));
        }

        public IEnumerable<T> Select<T>(Func<IEnumerable<object>, T> dataSelector) => Rows().Select(r => dataSelector(r));

        public IEnumerable<IEnumerable<object>> Where(Func<IEnumerable<object>, bool> predicate) => Rows().Where(r => predicate(r));

        public IEnumerable<T> Where<T>(Func<IEnumerable<object>, T> dataSelector, Func<T, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (dataSelector == null) throw new ArgumentNullException("dataselector");

            return Select(r => dataSelector(r)).Where(predicate);
        }

        public bool IsColumnUniqueType(int index) => Column[index].Select(d => d.GetType()).Distinct().Count() == 1;
    }

    public class DataTable<T> : Projection<T>
    {
        protected ColumnSelector<T> ColumnSelector { get; private set; }

        public DataTable() : this(0)
        {

        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            IEnumerable<string> headers = null,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, dataStoreType, headers: headers)
        {
            ColumnSelector = new ColumnSelector<T>(this);

            Column = new DataColumnIndexer<T>(Data, (n) => ColumnSelector.GetColumnIndex(n), n => AddHeader(n));
            Row = new DataRowIndexer<T>(Data);
        }

        public DataTable(IDataStore<T> data) : base(data)
        {
            ColumnSelector = new ColumnSelector<T>(this);

            Column = new DataColumnIndexer<T>(Data, (n) => ColumnSelector.GetColumnIndex(n), n => AddHeader(n));
            Row = new DataRowIndexer<T>(Data);
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

        public INamedIndexer<T, IEnumerable<T>> Column { get; protected set; }
        public IIndexer<T, IEnumerable<T>> Row { get; protected set; }

        public DataColumn<T> GetDataColumn(int columnIndex) => new DataColumn<T>(Data, columnIndex);
        public DataRow<T> GetDataRow(int rowIndex) => new DataRow<T>(Data, rowIndex);

        private void AssertColumnCount(IEnumerable<T> row)
        {
            if (Data.ColumnCount > 0 && row.Count() != Data.ColumnCount) throw new IncorrectRowLengthException(row.Count(), Data.ColumnCount);
        }

        private static void AssertConsistentRowLength(IEnumerable<IEnumerable<T>> data)
        {
            if (data.Select(d => d.Count()).Distinct().Count() > 1) throw new InconsistentRowLengthException();
        }

        public int ColumnCount { get => Data.ColumnCount; set => Data.ColumnCount = value; }
        public int RowCount { get => Data.RowCount; }

        public void AddHeader(string headerName)
        {
            string[] headers = Headers;

            Array.Resize(ref headers, Headers.Length + 1);

            headers[^1] = headerName;

            int i = 1;
            int j = 7;
            headers[^i] = headerName;
            Console.WriteLine(headers[1..7]);
            Console.WriteLine(headers[i..j]);
            new List<string>().Count();
            Headers = headers;
        }

        public void TransformColumn(string columnName, BaseTransformation<T, T> transformer)
        {
            TransformColumn(ColumnSelector.GetColumnIndex(columnName), transformer);
        }

        public void TransformColumn(int index, BaseTransformation<T, T> transformer)
        {
            Column[index] = Column[index].Select(i => transformer.Transform(i));
        }

        public void TransformRow(int index, BaseTransformation<T, T> transformer)
        {
            Row[index] = Row[index].Select(i => transformer.Transform(i));
        }
    }
}
