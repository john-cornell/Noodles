using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Extensions;

namespace Noodles.Data.Selectors
{
    public class ColumnSelector<T>
    {
        protected DataTable<T> DataTable { get; private set; }

        public ColumnSelector(DataTable<T> dataTable)
        {
            DataTable = dataTable;
        }

        public IEnumerable<T> this[int i] => DataTable.Column[i];
        public IEnumerable<T> this[string columnName]
        {
            get
            {
                int index = DataTable
                    .Headers
                    .Select(h => h.ToUpperInvariant())
                    .IndexOf(columnName.ToUpperInvariant());

                return this[index];
            }
        }
    }
}
