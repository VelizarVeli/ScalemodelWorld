using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models.Contracts
{
    public interface IBase
    {
        [Required]
        string FactoryNumber { get; set; }

        [Required]
        string Manifacturer { get; set; }
    }
}