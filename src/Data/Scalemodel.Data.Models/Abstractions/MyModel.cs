using System;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Contracts;

namespace Scalemodel.Data.Models.Abstractions
{
    public abstract class MyModel : BaseModel, IMyModel
    {
        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string Place { get; set; }

        public string OwnerId { get; set; }
        public ScalemodelWorldUser Owner { get; set; }
    }
}