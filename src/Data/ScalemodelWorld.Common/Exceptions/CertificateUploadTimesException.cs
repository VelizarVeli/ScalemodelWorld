namespace ScalemodelWorld.Common.Exceptions
{
    public class CertificateUploadTimesException : HealthBlogBaseException
    {
        private const string message = "You have exceed your certificate upload times!";

        public CertificateUploadTimesException()
            : base(message)
        {
        }
    }
}
