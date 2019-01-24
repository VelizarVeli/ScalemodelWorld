using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class WishlistBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        [Required]
        public string Manifacturer { get; set; }

        public string UserId { get; set; }

        public string LinkToScalemates { get; set; }

        public string BoxPicture { get; set; }

        public int Number { get; set; }

        public int  Scale { get; set; }

        public string Category { get; set; }
    }
}
