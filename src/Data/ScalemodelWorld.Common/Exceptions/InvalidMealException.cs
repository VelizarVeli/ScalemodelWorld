namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidMealException : HealthBlogBaseException
    {
        private const string message = "Meal not found!";

        public InvalidMealException()
            : base(message)
        {
        }
    }
}
