﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IStartedScalemodelsService
    {
        Task<IEnumerable<AllStartedModelsViewModel>> AllStarted(string userId);
        Task<StartedScalemodelBindingModel> GetStartedScalemodelDetailsAsync(int id, string username);
        Task FinishBuildAsync(int id, string userId);
        Task StartedDeleteAsync(int modelId, string userId);
        Task StartedEditAsync(StartedScalemodelBindingModel scalemodel, int modelId, string userId);
    }
}
