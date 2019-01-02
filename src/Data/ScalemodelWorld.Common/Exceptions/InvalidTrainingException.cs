namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidTrainingException : HealthBlogBaseException
    {
        private const string message = "Training not found!";

        public InvalidTrainingException()
            : base(message)
        {
        }
    }
}
