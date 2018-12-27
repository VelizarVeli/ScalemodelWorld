using System.Collections.Generic;
using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models
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
