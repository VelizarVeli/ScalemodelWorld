namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidTrainingExerciseException : HealthBlogBaseException
    {
        private const string message = "Exercise is not found in that training!";

        public InvalidTrainingExerciseException()
            : base(message)
        {
        }
    }
}
