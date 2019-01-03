using System;
using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Web.ViewModels.Scalemodels
{
    public class AddBindingModel
    {
        public string BoxPicture { get; set; }

        [Display(Name = "Link to the model in Scalemates")]
        public string LinkToScalemates { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int Scale { get; set; }

        public string Manifacturer { get; set; }

        public string FactoryNumber { get; set; }

        public string CombinesWith { get; set; }

        public string InfoHowTo { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Place { get; set; }

        public string BestCompanyOffer { get; set; }

        public string Comments { get; set; }
    }
}
