﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task<IEnumerable<AllCompletedModelsViewModel>> CompletedAll(string userId);
        Task<CompletedScalemodelBindingModel> GetCompletedScalemodelDetailsAsync(int id, string username);
        Task CompletedDeleteAsync(int modelId, string userId);
        Task CompletedEditAsync(CompletedScalemodelBindingModel scalemodel, int modelId, string userId);
    }
}
