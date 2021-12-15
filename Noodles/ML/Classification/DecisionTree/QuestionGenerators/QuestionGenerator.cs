using static Noodles.ML.Classification.DecisionTree.Question;

namespace Noodles.ML.Classification.DecisionTree.QuestionGenerators
{
    internal abstract class QuestionGenerator
    {
        public decimal Purity { get; protected set; }

        public QuestionGenerator(QuestionType type)
        {
            Type = type;
        }

        public QuestionType Type { get; protected set; }

        public abstract Question Generate(DecisionGeneratorContext context);
    }
}