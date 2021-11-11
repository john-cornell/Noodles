using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Exceptions;

namespace Noodles.Data.Validations
{
    public class Validation_RowsContainDistinctDataTypes : Validation
    {
        public Validation_RowsContainDistinctDataTypes() : base(ValidationType.RowsContainDistinctDataTypes)
        {
        }

        protected override void Validate(DataTable dataTable)
        {
            int index = 0;

            List<int> invalidRows = new List<int>();

            foreach (IEnumerable<object> row in dataTable.Rows())
            {
                if (row.Select(r => r.GetType()).Distinct().Count() > 1) invalidRows.Add(index);

                index++;
            }

            if (invalidRows.Count > 0)
            {
                throw new ValidationException($"Rows {string.Join(",", invalidRows)} do not contain distinct data types", ValidationType.RowsContainDistinctDataTypes);
            }
        }
    }
}
