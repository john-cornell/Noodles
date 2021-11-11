using System.Linq;
using Noodles.Data.Projections;
using Noodles.Exceptions;
using Noodles.Test.ExtensionTests;

namespace Noodles.Data.Validations
{
    public class Validation_AllNumeric : Validation
    {
        public Validation_AllNumeric() : base(ValidationType.AllNumeric)
        {

        }

        protected override void Validate(DataTable dataTable)
        {
            if (dataTable
                    .Rows()
                    .SelectMany(r => r)
                    .Where(d => d != null)
                    .Any(d => !d.IsNumber()))
            {
                throw new ValidationException(ValidationType.AllNumeric);
            }
        }
    }
}
