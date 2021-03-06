﻿using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Enums;

namespace Scalemodel.Data.Models.Abstractions
{
    public abstract class BaseModel : BaseId
    {
        [Required]
        public int Scale { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string CombinesWith { get; set; }

        public string BestCompanyOffer { get; set; }

        public string InfoHowTo { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Comments { get; set; }

        public string BoxPicture { get; set; }

        public string LinkToScalemates { get; set; }

        public Category Category { get; set; }
    }
}