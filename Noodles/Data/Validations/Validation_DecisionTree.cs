using System;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Data.Validations.Context;
using Noodles.Exceptions;
using Noodles.Test.ExtensionTests;

namespace Noodles.Data.Validations
{
    public class Validation_DecisionTree : Validation
    {
        private readonly Validation_ColumnsContainDistinctDataTypes _distinctTypeValidator;

        public Validation_DecisionTree() : base(ValidationType.DecisionTree)
        {
            _distinctTypeValidator = new Validation_ColumnsContainDistinctDataTypes();
        }

        protected override void Validate(DataTable dataTable)
        {
            if (Context == null) throw new NullValidationContextException(ValidationType.DecisionTree);
            if (Context.ValidationType != ValidationType.DecisionTree) throw new IncorrectValidationContextException(ValidationType.DecisionTree, Context.ValidationType);

            _distinctTypeValidator.Validate(dataTable, null);

            //Can check 1st row only as above we've ensured all columns are of a like type
            foreach (object item in dataTable.Row[0])
            {
                if (item.IsNumber() || item is string || item is bool) continue;

                throw new ValidationException($"Only numeric, boolean or string types are valid for Decision Tree. {item.GetType()} invalid.", ValidationType.DecisionTree);
            }

            int labelColumn = Context.As<DecisionTreeValidationContext>().OverrideLabelColumn.IfNull
                (
                    dataTable.ColumnCount - 1
                ).Value;

            //We know that all columns are distinct data types, so we can just grab the first item;
            object instance = dataTable.Column[labelColumn].First();

            if (!instance.IsNumeric() && !(instance is bool))
            {
                throw new ValidationException($"Label column datatype must be numeric 0 and 1, or bool. Invalid data type {instance.GetType()}", ValidationType.DecisionTree);
            }
            else if (instance.IsNumeric() &&
                dataTable.Column[labelColumn]
                    .Count(n =>
                    {
                        int i = Convert.ToInt32(n);
                        return i != 0 && i != 1;
                    }) != 0)
            {
                throw new ValidationException($"Label column datatype must be numeric 0 and 1. Invalid values detected", ValidationType.DecisionTree);
            }

            if (dataTable.Column[labelColumn].Count(i => i != null) < dataTable.RowCount) throw new ValidationException("Label column does not cover all rows", ValidationType.DecisionTree);

        }
    }
}
