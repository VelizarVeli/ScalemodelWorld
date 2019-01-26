using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IPurchasedScalemodelsService
    {
        Task<IEnumerable<AllPurchasedModelsViewModel>> AllPurchased(string id);
        Task AddPurchasedAsync(PurchasedScalemodelBindingModel scalemodel, string id);
        Task<PurchasedScalemodelBindingModel> GetPurchasedScalemodelDetailsAsync(int id, string username);
        Task StartNewBuildAsync(int id, string userId);
        Task PurchasedDeleteAsync(int modelId, string userId);
        Task PurchasedEditAsync(PurchasedScalemodelBindingModel scalemodel, int modelId, string userId);
    }
}
