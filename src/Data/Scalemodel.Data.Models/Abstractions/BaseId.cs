using System.ComponentModel.DataAnnotations;
using Scalemodels.Models.Contracts;

namespace Scalemodels.Models.Abstractions
{
    public abstract class BaseId : IBaseId<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
