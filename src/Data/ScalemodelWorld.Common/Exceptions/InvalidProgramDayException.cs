namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidProgramDayException : HealthBlogBaseException
    {
        private const string message = "Invalid day in program";

        public InvalidProgramDayException()
            : base(message)
        {
        }
    }
}
