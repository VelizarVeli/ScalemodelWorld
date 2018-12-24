using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models.Contracts
{
    interface IBaseId<T>
    {
        [Key]
        T Id { get; set; }
    }
}
