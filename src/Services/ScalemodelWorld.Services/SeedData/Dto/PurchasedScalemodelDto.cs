using System;

namespace ScalemodelWorld.Services.SeedData.Dto
{
    public class PurchasedScalemodelDto
    {
        public string Id { get; set; }

        public string BoxPicture { get; set; }

        public string LinkToScalemates { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int Scale { get; set; }

        public string Manifacturer { get; set; }

        public string FactoryNumber { get; set; }

        public string CombinesWith { get; set; }

        public string InfoHowTo { get; set; }

        public string Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Place { get; set; }

        public string BestCompanyOffer { get; set; }

        public string Comments { get; set; }

        public string OwnerId { get; set; }
    }
}
