using Scalemodels.Models.Abstractions;

namespace Scalemodels.Models
{
    public class Book : BaseId
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Place { get; set; }
    }
}
