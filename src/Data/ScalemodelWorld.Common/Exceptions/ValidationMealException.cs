namespace ScalemodelWorld.Common.Exceptions
{
    public class ValidationMealException : HealthBlogBaseException
    {
        private const string message = "You can't open that meal.";

        public ValidationMealException()
            : base(message)
        {
        }
    }
}
