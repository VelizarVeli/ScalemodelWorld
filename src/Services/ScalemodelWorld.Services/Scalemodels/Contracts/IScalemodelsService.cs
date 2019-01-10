using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Services.SeedData.Dto;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task<IEnumerable<AllCompletedModelsViewModel>> CompletedAll(string userId);
        Task<CompletedScalemodelDto> GetCompletedScalemodelDetailsAsync(int id, string username);
        Task CompletedDeleteAsync(int modelId, string userId);
        Task CompletedEditAsync(CompletedScalemodelDto scalemodel, int modelId, string userId);
    }
}
