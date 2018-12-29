using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models
{
    public class Aftermarket : Base
    {
        public Aftermarket()
        {
            this.AvailableScalemodels = new HashSet<AvailableAftermarket>();
            this.CompletedScalemodels = new HashSet<CompletedAftermarket>();
            this.StartedScalemodels = new HashSet<StartedAftermarket>();
        }

        public int Id { get; set; }

        public int? Number { get; set; }

        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Price { get; set; }

        public bool Purchased { get; set; } = false;

        public ICollection<AvailableAftermarket> AvailableScalemodels { get; set; }

        public ICollection<CompletedAftermarket> CompletedScalemodels { get; set; }

        public ICollection<StartedAftermarket> StartedScalemodels { get; set; }

        public int OwnerId { get; set; }
        public ScalemodelWorldUser Owner { get; set; }
    }
}