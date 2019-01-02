namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidMealDayException : HealthBlogBaseException
    {
        private const string message = "Day doesn't contain that meal!";
        public InvalidMealDayException()
            : base(message)
        {
        }
    }
}
