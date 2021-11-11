using System;
using Noodles.Data.Projections;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DecisionTreeClassifier
    {
        DataTable _sourceData;

        public DecisionTreeClassifier(DataTable sourceData)
        {
            ValidateData(sourceData);
        }

        private void ValidateData(DataTable sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
