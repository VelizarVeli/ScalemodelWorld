using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models.Contracts
{
    public interface IBase
    {
        [Required]
        string FactoryNumber { get; set; }

        int ManifacturerId { get; set; }
        [Required]
        Manifacturer Manifacturer { get; set; }
    }
}