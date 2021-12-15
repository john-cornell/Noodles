using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;
using Noodles.Exceptions;
using static Noodles.ML.Classification.DecisionTree.Question;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DecisionGeneratorContext
    {
        public DataTable Table { get; set; }
        public DataSliceTracker ColumnTracker { get; set; }
        public DataSliceTracker RowTracker { get; set; }

        public Dictionary<int, HashSet<object>> CategoricalData { get; set; }
        public Dictionary<int, QuestionType> QuestionTypes { get; set; }

        readonly QuestionTypeClassifier _classifier;

        public DecisionGeneratorContext(DataTable dataTable, DataSliceTracker columnTracker = null, DataSliceTracker rowTracker = null, Dictionary<int, QuestionType> hints = null)
        {
            _classifier = new QuestionTypeClassifier();

            Table = dataTable;
            ColumnTracker = columnTracker ?? new DataSliceTracker(dataTable, DataSliceTracker.Slice.Column);
            RowTracker = rowTracker ?? new DataSliceTracker(dataTable, DataSliceTracker.Slice.Row);

            LoadState(hints ?? new Dictionary<int, QuestionType>());
        }

        private void LoadState(Dictionary<int, QuestionType> hints)
        {
            CategoricalData = new Dictionary<int, HashSet<object>>();
            QuestionTypes = new Dictionary<int, QuestionType>();

            foreach (int columnIndex in ColumnTracker)
            {
                IEnumerable<object> columnData = Table.Column[columnIndex];

                ClassifyColumn(columnIndex, columnData, hints.ContainsKey(columnIndex) ? hints[columnIndex] : QuestionType.None);
            }
        }

        private void ClassifyColumn(int columnIndex, IEnumerable<object> columnData, QuestionType hint)
        {
            QuestionTypes[columnIndex] = _classifier.ClassifyColumn(columnData, hint: hint);


            switch (QuestionTypes[columnIndex])
            {
                case QuestionType.None:
                    throw new UnableToClassifyDataException(columnData.First().GetType().ToString());
                case QuestionType.CategoricalNumeric:
                case QuestionType.Labels:
                    CategoricalData[columnIndex] = new HashSet<object>(columnData.Distinct());
                    break;
                default:
                    break;
            }
        }
    }
}
