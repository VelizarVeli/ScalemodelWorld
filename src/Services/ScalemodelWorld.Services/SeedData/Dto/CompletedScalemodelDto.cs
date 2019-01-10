using System;
using System.ComponentModel.DataAnnotations;
using ScalemodelWorld.Common.Constants;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class CompletedScalemodelDto
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.BoxPicture)]
        public string BoxPicture { get; set; }

        [Display(Name = AttributeDisplayNameConstants.LinkToScalemates)]
        public string LinkToScalemates { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(ModelsLengthConstants.NameMaxLength, MinimumLength = ModelsLengthConstants.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public int Scale { get; set; }

        [Required]
        [StringLength(ModelsLengthConstants.ManifacturerNameMaxLength, MinimumLength = ModelsLengthConstants.ManifacturerNameMinLength)]
        public string Manifacturer { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.FactoryNumber)]
        public string FactoryNumber { get; set; }

        [Display(Name = AttributeDisplayNameConstants.CombinesWith)]
        public string CombinesWith { get; set; }

        [Display(Name = AttributeDisplayNameConstants.InfoHowTo)]
        public string InfoHowTo { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.DateOfPurchase)]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public string Place { get; set; }

        [Display(Name = AttributeDisplayNameConstants.BestCompanyOffer)]
        public string BestCompanyOffer { get; set; }

        public string Comments { get; set; }

        public string OwnerId { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.StartingDate)]
        public DateTime StartingDate { get; set; }

        public string GivenSold { get; set; }

        [Display(Name = AttributeDisplayNameConstants.PicturesLink)]
        public string PicturesLink { get; set; }

        [Display(Name = AttributeDisplayNameConstants.ForumsLink)]
        public string ForumsLink { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.FinishingDate)]
        public DateTime FinishingDate { get; set; }
    }
}
