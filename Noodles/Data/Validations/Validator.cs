using System;
using System.Collections.Generic;
using Noodles.Data.Projections;
using Noodles.Data.Validations.Context;

namespace Noodles.Data.Validations
{
    public enum ValidationType
    {

        Unknown = 0,

        AllNumeric = 1 << 0,
        RowsContainDistinctDataTypes = 1 << 1,
        AllDataDistinctType = 1 << 2,

        DecisionTree = 1 << 42,
    }

    public class Validator
    {
        private List<Validation> _validators;

        public Validator()
        {
            LoadValidation();
        }

        public void Validate(DataTable table, ValidationType types, ValidationContext context = null)
        {
            bool validationFound = false;

            foreach (Validation validator in _validators)
            {
                if ((types & validator.ValidationType) > 0)
                {


                    validator.Validate(table, context);
                    validationFound = true;
                }
            }

            if (!validationFound)
                throw new Exception($"No validator available for {types}");
        }

        private void LoadValidation()
        {
            _validators = new List<Validation>();

            Add<Validation_AllNumeric>();
            Add<Validation_RowsContainDistinctDataTypes>();
            Add<Validation_AllDataDistinct>();
            Add<Validation_DecisionTree>();
        }

        private void Add<T>() where T : Validation
        {
            _validators.Add(Activator.CreateInstance<T>());
        }
    }
}
