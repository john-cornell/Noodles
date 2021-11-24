using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Test.Data;

namespace Noodles.Test.Utilities
{
    public enum DataLoadStrategy { EnumOfEnum, RowByRow, Params, ByDataRows, ByDataColumns }

    public class DataProvider
    {
        readonly RandomProvider _random;

        public DataProvider()
        {
            _random = new RandomProvider();
        }

        public List<List<decimal>> GetTableListData(int columns = 0, int rows = 0)
        {
            columns = columns > 0 ? columns : _random.GetRandomInt(5, 11);
            rows = rows > 0 ? rows : _random.GetRandomInt(5, 100);

            List<List<decimal>> testData = new List<List<decimal>>();

            for (int i = 0; i < rows; i++) testData.Add(_random.GetRandomDecimals(columns).ToList());

            return testData;
        }

        public List<List<object>> GetObjectData(int columns, int rows, Func<int, bool> isNumericColumn)
        {
            List<List<object>> data = new List<List<object>>();

            for (int i = 0; i < rows; i++)
            {
                List<object> row = new List<object>();
                data.Add(row);

                for (int j = 0; j < columns; j++)
                {
                    if (isNumericColumn(j))
                        row.Add(_random.GetRandomDecimal());
                    else
                        row.Add(_random.GetRandomWord());
                }
            }

            return data;
        }

        public TestDataContext GetTestDataContext(DataStoreType dataStoreType, DataLoadStrategy strategy, int? rows = null, int? columns = null)
        {
            List<List<decimal>> testData = GetTableListData(columns: columns ?? 0, rows: rows ?? 0);

            DataTable<decimal> table = GetNewTable(dataStoreType, strategy, testData.First().Count);

            testData = LoadData(table, testData, strategy);

            return new TestDataContext
            {
                Table = table,
                TestData = testData
            };
        }

        private static DataTable<decimal> GetNewTable(DataStoreType dataStoreType, DataLoadStrategy strategy, int columnSize)
        {
            return new DataTable<decimal>(
                            strategy == DataLoadStrategy.ByDataColumns ||
                            strategy == DataLoadStrategy.ByDataRows
                            ? columnSize : 0,
                            dataStoreType: dataStoreType);
        }

        public List<List<decimal>> LoadData(DataTable<decimal> table, List<List<decimal>> testData, DataLoadStrategy strategy)
        {
            switch (strategy)
            {
                case DataLoadStrategy.EnumOfEnum:
                    table.Add(testData);
                    break;
                case DataLoadStrategy.RowByRow:
                    testData.ForEach(d => table.Add(d));
                    break;
                case DataLoadStrategy.Params:

                    testData = testData.Take(5).ToList();

                    table.Add(
                        testData[0].ToArray(),
                        testData[1].ToArray(),
                        testData[2].ToArray(),
                        testData[3].ToArray(),
                        testData[4].ToArray()
                        );
                    break;
                case DataLoadStrategy.ByDataRows:

                    for (int i = 0; i < testData.Count; i++)
                    {
                        table.Row[i] = testData[i];
                    }

                    break;
                case DataLoadStrategy.ByDataColumns:

                    List<List<decimal>> pivoted = new List<List<decimal>>();

                    for (int j = 0; j < testData[0].Count; j++)
                    {
                        pivoted.Add(new List<decimal>());

                        foreach (List<decimal> row in testData)
                        {
                            pivoted[j].Add(row[j]);
                        }
                    }

                    for (int i = 0; i < pivoted.Count; i++)
                    {
                        table.Column[i] = pivoted[i];
                    }

                    break;

                default:
                    break;
            }

            return testData;
        }

        public DataRowContext GetDataRowContext(
            DataStoreType dataStoreType,
            DataLoadStrategy dataLoadStrategy,
            DataRowCreationMethod creationMethod, int? row = null)
        {
            TestDataContext context = GetTestDataContext(dataStoreType, dataLoadStrategy);

            if (!row.HasValue) row = _random.GetRandomInt(0, context.Table.RowCount);

            DataRow<decimal> dataRow = creationMethod switch
            {
                DataRowCreationMethod.FromCtorWithDataStore => new DataRow<decimal>(context.Table.Data, row.Value),
                DataRowCreationMethod.FromCtorWithProjection => new DataRow<decimal>(context.Table, row.Value),
                DataRowCreationMethod.FromTable => context.Table.GetDataRow(row.Value),
                _ => throw new InvalidOperationException($"Data Creation Method {creationMethod} not found"),
            };

            return new DataRowContext
            {
                Context = context,
                Row = dataRow,
                Index = row.Value
            };
        }
        public DataColumnContext GetDataColumnContext(
        DataStoreType dataStoreType,
        DataLoadStrategy dataLoadStrategy,
        DataColumnCreationMethod creationMethod, int? column = null)
        {
            TestDataContext context = GetTestDataContext(dataStoreType, dataLoadStrategy);

            if (!column.HasValue) column = _random.GetRandomInt(0, context.Table.ColumnCount);

            DataColumn<decimal> dataColumn = creationMethod switch
            {
                DataColumnCreationMethod.FromCtorWithDataStore => new DataColumn<decimal>(context.Table.Data, column.Value),
                DataColumnCreationMethod.FromCtorWithProjection => new DataColumn<decimal>(context.Table, column.Value),
                DataColumnCreationMethod.FromTable => context.Table.GetDataColumn(column.Value),
                _ => throw new InvalidOperationException($"Data Creation Method {creationMethod} not found"),
            };

            return new DataColumnContext
            {
                Column = dataColumn,
                Context = context,
                Index = column.Value
            };
        }
    }

    public class TestDataContext
    {
        public DataTable<decimal> Table { get; set; }
        public List<List<decimal>> TestData { get; set; }
    }

    public class DataRowContext
    {
        public TestDataContext Context { get; set; }
        public DataRow<decimal> Row { get; set; }
        public int Index { get; set; }
    }

    public class DataColumnContext
    {
        public TestDataContext Context { get; set; }
        public DataColumn<decimal> Column { get; set; }
        public int Index { get; set; }
    }

}
