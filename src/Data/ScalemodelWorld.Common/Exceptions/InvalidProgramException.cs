namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidProgramException : HealthBlogBaseException
    {
        private const string message = "Program not found!";

        public InvalidProgramException()
            : base(message)
        {
        }
    }
}
