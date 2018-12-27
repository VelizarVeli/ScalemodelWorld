using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Contracts;

namespace Scalemodel.Data.Models.Abstractions
{
    public abstract class BaseId : IBaseId<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
