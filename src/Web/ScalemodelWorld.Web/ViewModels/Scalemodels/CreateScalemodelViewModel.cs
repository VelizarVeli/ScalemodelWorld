using System;
using System.ComponentModel.DataAnnotations;
using Scalemodels.Models;

namespace ScalemodelWorld.Web.ViewModels.Scalemodels
{
    public class CreateScalemodelViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime StartingDate { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string Place { get; set; }

        [Required]
        public int Scale { get; set; }

        [Required]
        public int Number { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string CombinesWith { get; set; }

        public string BestCompanyOffer { get; set; }

        public string InfoHowTo { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public string Comments { get; set; }
    }
}
