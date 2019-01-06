using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class WishListDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        [Required]
        public string Manifacturer { get; set; }
    }
}
