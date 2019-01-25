using System;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Enums;
using ScalemodelWorld.Common.Constants;

namespace ScalemodelWorld.Common.Scalemodels.ViewModels
{
    public class AllCompletedModelsViewModel
    {
        public string Id { get; set; }

        [Display(Name = AttributeDisplayNameConstants.BoxPicture)]
        public string BoxPicture { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Manifacturer { get; set; }

        [DisplayFormat(DataFormatString = AttributeDisplayNameConstants.StartingDate)]
        public DateTime StartingDate { get; set; }

        [DisplayFormat(DataFormatString = AttributeDisplayNameConstants.StartingDate)]
        public DateTime FinishingDate { get; set; }

        [Display(Name = AttributeDisplayNameConstants.DayFormat)]
        public string LinkToScalemates { get; set; }

        public Category Category { get; set; }
    }
}
