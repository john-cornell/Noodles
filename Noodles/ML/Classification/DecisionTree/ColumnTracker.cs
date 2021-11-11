using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Data.Selectors;
using Noodles.Exceptions;

namespace Noodles.ML.Classification.DecisionTree
{
    public class ColumnTracker<T> : ColumnSelector<T>, IEnumerable<IEnumerable<T>>
    {
        public HashSet<int> AvailableColumns { get; private set; }

        public ColumnTracker(DataTable<T> dataTable) : base(dataTable)
        {
            AvailableColumns = new HashSet<int>(Enumerable.Range(0, dataTable.ColumnCount));
        }

        public void RemoveColumn(int index)
        {
            if (AvailableColumns.Contains(index))
            {
                AvailableColumns.Remove(index);
            }
            else
            {
                throw new InvalidValueException($"Column {0} is not available to remove");
            }
        }

        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            foreach (int column in AvailableColumns) yield return DataTable.Column[column];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
