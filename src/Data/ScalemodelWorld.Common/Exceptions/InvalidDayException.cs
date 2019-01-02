namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidDayException : HealthBlogBaseException
    {
        private const string message = "Day not found!";

        public InvalidDayException()
            : base(message)
        {
        }
    }
}
