namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidUserException : HealthBlogBaseException
    {
        private const string message = "User not found!";

        public InvalidUserException() : base(message)
        {
        }
    }
}
