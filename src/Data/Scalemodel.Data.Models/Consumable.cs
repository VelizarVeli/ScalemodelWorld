using System;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
{
    public class Consumable : BaseId
    {
        public string Name { get; set; }

        public string Manifacturer { get; set; }

        public string ManifacturerNumber { get; set; }

        public string Coverage { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfPurchase { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }
        public ConsumableCategory Category { get; set; }

        public int OwnerId { get; set; }
        public ScalemodelWorldUser Owner { get; set; }
    }
}
