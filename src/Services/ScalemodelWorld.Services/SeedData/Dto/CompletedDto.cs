using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class CompletedDto
    {
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Scale { get; set; }

        public string Manifacturer { get; set; }

        public string FactoryNumber { get; set; }

        public string Placement { get; set; }

        public string BestCompanyOffer { get; set; }

        public string GivenSold { get; set; }

        public string PicturesLink { get; set; }

        public string ForumsLink { get; set; }

        public string CombinesWith { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public string DateOfPurchase { get; set; }

        public string StartedOnDate { get; set; }

        public string FinishedOnDate { get; set; }
    }
}
