using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Exceptions;

namespace Noodles.Data.Validations
{
    public class Validation_ColumnsContainDistinctDataTypes : Validation
    {
        public Validation_ColumnsContainDistinctDataTypes() : base(ValidationType.ColumnsContainDistinctDataTypes)
        {
        }

        protected override void Validate(DataTable dataTable)
        {
            int index = 0;

            List<int> invalidColumns = new List<int>();

            foreach (IEnumerable<object> column in dataTable.Columns())
            {
                if (column.Where(c => c != null).Select(c => c.GetType()).Distinct().Count() > 1) invalidColumns.Add(index);

                index++;
            }

            if (invalidColumns.Count > 0)
            {
                throw new ValidationException($"Columns {string.Join(",", invalidColumns)} do not contain distinct data types", ValidationType.ColumnsContainDistinctDataTypes);
            }
        }
    }
}
