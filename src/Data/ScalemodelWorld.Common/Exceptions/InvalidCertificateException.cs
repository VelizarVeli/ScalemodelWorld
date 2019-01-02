namespace ScalemodelWorld.Common.Exceptions
{
    public class InvalidCertificateException : HealthBlogBaseException
    {
        private const string message = "Certificate not found!";

        public InvalidCertificateException()
            : base(message)
        {
        }
    }
}
