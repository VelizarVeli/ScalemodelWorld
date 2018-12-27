using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models.Contracts
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