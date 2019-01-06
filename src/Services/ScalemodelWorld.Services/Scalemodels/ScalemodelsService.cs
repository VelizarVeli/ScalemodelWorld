using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Services.Scalemodels
{
    public class ScalemodelsService : BaseService, IScalemodelsService
    {
        public ScalemodelsService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task AddScalemodelAsync(AvailableScalemodelBindingModel scalemodel, string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            CoreValidator.ThrowIfNull(scalemodel);

            scalemodel.OwnerId = user.Id;

            var model = this.Mapper.Map<AvailableScalemodel>(scalemodel);
            var biggestNumber = DbContext.AvailableScalemodels.Where(a => a.OwnerId == scalemodel.OwnerId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            model.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;
            user.PurchasedModels.Add(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllModelsViewModel>> AvailableAll(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allAvailable = this.Mapper.Map<IEnumerable<AllModelsViewModel>>(
                this.DbContext.AvailableScalemodels.Where(i => i.OwnerId == user.Id));

            return allAvailable;
        }

        public async Task<AvailableScalemodelBindingModel> GetAvailableScalemodelDetailsAsync(int id, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var availableModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<AvailableScalemodelBindingModel>(availableModel);

            return scalemodel;
        }

        public async Task<IEnumerable<AllModelsViewModel>> StartedAll(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allstarted = this.Mapper.Map<IEnumerable<AllModelsViewModel>>(
                this.DbContext.StartedScalemodels.Where(i => i.OwnerId == user.Id));

            return allstarted;
        }

        public async Task StartNewBuildAsync(int id, string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var availableModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var started = this.Mapper.Map<StartedScalemodel>(availableModel);
            var biggestNumber = DbContext.StartedScalemodels.Where(a => a.OwnerId == userId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            started.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;

            user.StartedModels.Add(started);
            user.PurchasedModels.Remove(availableModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task AvailableDeleteAsync(int modelId, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var availableModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            this.DbContext.AvailableScalemodels.Remove(availableModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task AvailableEditAsync(AvailableScalemodelBindingModel scalemodel, int modelId, string userId)
        {
            var model = DbContext.AvailableScalemodels.Find(modelId);
            Mapper.Map(scalemodel, model);
            model.OwnerId = userId;
            DbContext.AvailableScalemodels.Update(model);
            await this.DbContext.SaveChangesAsync();
        }

        //private async Task updateNumbers(int oldNumberValue, int editedNumber)
        //{
        //    var availableModels = DbContext.AvailableScalemodels.AddRangeAsync()

        //    if (oldNumberValue > editedNumber)
        //    {
        //        for (int i = editedNumber; i < oldNumberValue; i++)
        //        {
        //            DbContext
        //        }
        //    }

        //    DbContext.SaveChangesAsync();
        //}
    }
}
