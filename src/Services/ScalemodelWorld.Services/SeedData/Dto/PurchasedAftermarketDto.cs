using System;
using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class PurchasedAftermarketDto
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string FactoryNumber { get; set; }

        public string Category { get; set; }

        public string Placement { get; set; }
    }
}
