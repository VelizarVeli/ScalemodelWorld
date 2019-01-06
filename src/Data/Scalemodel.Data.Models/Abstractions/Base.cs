using Scalemodel.Data.Models.Contracts;

namespace Scalemodel.Data.Models.Abstractions
{
    public abstract class Base : IBase
    {
        public string FactoryNumber { get; set; }

        public string Manifacturer { get; set; }
    }
}
