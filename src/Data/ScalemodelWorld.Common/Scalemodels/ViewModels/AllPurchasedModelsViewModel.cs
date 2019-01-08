using System;
using System.ComponentModel.DataAnnotations;
using ScalemodelWorld.Common.Constants;

namespace ScalemodelWorld.Common.Scalemodels.ViewModels
{
    public class AllPurchasedModelsViewModel
    {
        public string Id { get; set; }

        [Display(Name = AttributeDisplayNameConstants.BoxPicture)]
        public string BoxPicture { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = AttributeDisplayNameConstants.DateOfPurchase)]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = AttributeDisplayNameConstants.DayFormat)]
        public string LinkToScalemates { get; set; }
    }
}
