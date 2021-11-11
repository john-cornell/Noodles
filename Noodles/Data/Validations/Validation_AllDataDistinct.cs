using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Exceptions;

namespace Noodles.Data.Validations
{
    public class Validation_AllDataDistinct : Validation
    {
        public Validation_AllDataDistinct() : base(ValidationType.AllDataDistinctType)
        {
        }

        protected override void Validate(DataTable dataTable)
        {
            IEnumerable<Type> types =
                dataTable
                .Rows()
                .SelectMany(r => r)
                .Where(r => r != null)
                .Select(r => r.GetType())
                .Distinct();

            if (types.Count() != 1)
            {
                throw new ValidationException(ValidationType.AllDataDistinctType);
            }
        }
    }
}
