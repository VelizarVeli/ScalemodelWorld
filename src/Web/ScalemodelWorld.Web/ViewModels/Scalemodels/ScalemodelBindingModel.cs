using System.ComponentModel.DataAnnotations;

namespace ScalemodelWorld.Web.ViewModels.Scalemodels
{
    public class ScalemodelBindingModel
    {
        public int Id { get; set; }

        [Display(Name = "Link to Box Cover")]
        public string BoxPicture { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int Scale { get; set; }

        public string Manifacturer { get; set; }

        [Display(Name = "Factory Number")]
        public string FactoryNumber { get; set; }

        [Display(Name = "Combines With")]
        public string CombinesWith { get; set; }

        public string InfoHowTo { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        public string DateOfPurchase { get; set; }

        public string Place { get; set; }

        [Display(Name = "Best Company Offer")]
        public string BestCompanyOffer { get; set; }

        public string Comments { get; set; }

        [Display(Name = "Link to the model in Scalemates")]
        public string LinkToScalemates { get; set; }
    }
}