using System;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models;

namespace ScalemodelWorld.Web.ViewModels.Scalemodels
{
    public class AvailableViewModel
    {
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
