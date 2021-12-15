namespace Noodles.ML.Classification.DecisionTree.QuestionGenerators
{
    internal class ContinuousDataQuestionGenerator : QuestionGenerator
    {
        public ContinuousDataQuestionGenerator() : base(Question.QuestionType.Continuous)
        {
        }

        public override Question Generate(DecisionGeneratorContext context, int column)
        {
        }
    }
}