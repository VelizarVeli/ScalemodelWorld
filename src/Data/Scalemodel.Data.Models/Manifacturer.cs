using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.Scalemodels;

namespace Scalemodel.Data.Models
{
    public class Manifacturer : BaseId
    {
        public Manifacturer()
        {
            this.Aftermarkets = new HashSet<Aftermarket>();
            this.AvailableScalemodels = new HashSet<AvailableScalemodel>();
            this.CompletedScalemodels = new HashSet<CompletedScalemodel>();
            this.StartedScalemodels = new HashSet<StartedScalemodel>();
            this.WishScalemodels = new HashSet<WishScalemodel>();
            this.Tools = new HashSet<Tool>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Aftermarket> Aftermarkets { get; set; }
        public ICollection<AvailableScalemodel> AvailableScalemodels { get; set; }
        public ICollection<CompletedScalemodel> CompletedScalemodels { get; set; }
        public ICollection<StartedScalemodel> StartedScalemodels { get; set; }
        public ICollection<WishScalemodel> WishScalemodels { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}