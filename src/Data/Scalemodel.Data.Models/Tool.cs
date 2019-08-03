using System;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
{
    public class Tool : BaseId
    {
        public string Name { get; set; }

        public string Manifacturer { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }
        public ScalemodelWorldUser Owner { get; set; }
    }
}
