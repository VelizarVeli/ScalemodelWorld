using System.Collections.Generic;
using Scalemodels.Models.Abstractions;
using Scalemodels.Models.JunctionClasses;

namespace Scalemodels.Models.Scalemodels
{
    public class AvailableScalemodel : MyModel
    {
        public AvailableScalemodel()
        {
            this.AvailableAndPurchasedAftermarkets = new HashSet<AvailableAftermarket>();
        }

        public ICollection<AvailableAftermarket> AvailableAndPurchasedAftermarkets { get; set; }
    }
}