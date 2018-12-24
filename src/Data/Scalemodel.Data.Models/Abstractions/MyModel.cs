using System;
using System.ComponentModel.DataAnnotations;
using Scalemodels.Models.Contracts;

namespace Scalemodels.Models.Abstractions
{
    public abstract class MyModel : BaseModel, IMyModel
    {
        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string Place { get; set; }
    }
}