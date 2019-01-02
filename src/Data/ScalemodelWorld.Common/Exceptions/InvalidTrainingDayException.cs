namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidTrainingDayException : HealthBlogBaseException
    {
        private const string message = "Day doesn't contain that training!";

        public InvalidTrainingDayException()
            : base(message)
        {
        }
    }
}
