using System;
using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
{
    public class Consumable : BaseId
    {
        public string Name { get; set; }

        public int ManifacturerId { get; set; }
        public Manifacturer Manifacturer { get; set; }

        public string ManifacturerNumber { get; set; }

        public string Coverage { get; set; }

        public decimal? Price { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }
        public ConsumableCategory Category { get; set; }
    }
}
