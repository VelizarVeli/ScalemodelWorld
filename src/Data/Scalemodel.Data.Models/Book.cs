using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
{
    public class Book : BaseId
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Place { get; set; }
    }
}
