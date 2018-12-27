using System;
using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
{
    public class Tool : BaseId
    {
        public string Name { get; set; }

        public int ManifacturerId { get; set; }
        public Manifacturer Manifacturer { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Description { get; set; }
    }
}
