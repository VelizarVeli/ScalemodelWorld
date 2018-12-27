using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models.Contracts
{
    interface IBaseId<T>
    {
        [Key]
        T Id { get; set; }
    }
}
