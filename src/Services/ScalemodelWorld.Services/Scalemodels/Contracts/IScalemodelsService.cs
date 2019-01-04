using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task AddScalemodelAsync(AddPurchasedScalemodelBindingModel scalemodel, string username);
    }
}
