using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models.Modelshows
{
    public class ModelShowCategory
    {
        [Key]
        public int Id { get; set; }

        public int ModelShowId { get; set; }
        public ModelShow ModelShow { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}