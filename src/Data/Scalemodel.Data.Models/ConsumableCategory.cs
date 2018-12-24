using System.Collections.Generic;
using Scalemodels.Models.Abstractions;

namespace Scalemodels.Models
{
    public class ConsumableCategory : BaseId
    {
        public ConsumableCategory()
        {
            this.Consumables = new HashSet<Consumable>();
        }

        public string CategoryName { get; set; }

        public ICollection<Consumable> Consumables { get; set; }
    }
}
