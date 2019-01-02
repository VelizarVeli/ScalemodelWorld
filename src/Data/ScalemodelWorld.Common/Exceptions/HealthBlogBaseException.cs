using System;

namespace ScalemodelWorld.Common.Exceptions
{
    public class HealthBlogBaseException:Exception
    {
        protected HealthBlogBaseException(
            string message)
            : base(message)
        {
        }
    }
}
