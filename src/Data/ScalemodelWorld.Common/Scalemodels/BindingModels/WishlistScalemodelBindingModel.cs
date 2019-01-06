﻿using System.ComponentModel.DataAnnotations;
using ScalemodelWorld.Common.Constants;

namespace ScalemodelWorld.Common.Scalemodels.BindingModels
{
    public class WishlistScalemodelBindingModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.BoxPicture)]
        public string BoxPicture { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.LinkToScalemates)]
        public string LinkToScalemates { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(ModelsLengthConstants.ManifacturerNameMaxLength, MinimumLength = ModelsLengthConstants.ManifacturerNameMinLength)]
        public string Manifacturer { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.FactoryNumber)]
        public string FactoryNumber { get; set; }

        public int Number { get; set; }

        public string UserId { get; set; }

        [Required]
        public int Scale { get; set; }
    }
}
