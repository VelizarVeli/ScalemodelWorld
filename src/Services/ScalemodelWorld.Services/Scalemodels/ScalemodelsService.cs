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

        public async Task<IEnumerable<AllAvailableModelsViewModel>> AvailableAll(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allAvailable = this.Mapper.Map<IEnumerable<AllAvailableModelsViewModel>>(
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

        public async Task<IEnumerable<AllStartedModelsViewModel>> StartedAll(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allstarted = this.Mapper.Map<IEnumerable<AllStartedModelsViewModel>>(
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

        public async Task<StartedScalemodelBindingModel> GetStartedScalemodelDetailsAsync(int id, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var startedModel = await this.DbContext.StartedScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<StartedScalemodelBindingModel>(startedModel);

            return scalemodel;
        }

        public async Task FinishBuildAsync(int id, string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var startModel = await this.DbContext.StartedScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var finished = this.Mapper.Map<CompletedScalemodel>(startModel);
            var biggestNumber = DbContext.CompletedScalemodels.Where(a => a.OwnerId == userId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            finished.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;

            user.CompletedModels.Add(finished);
            user.StartedModels.Remove(startModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartedDeleteAsync(int modelId, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var startedModel = await this.DbContext.StartedScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            this.DbContext.StartedScalemodels.Remove(startedModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartedEditAsync(StartedScalemodelBindingModel scalemodel, int modelId, string userId)
        {
            var model = DbContext.StartedScalemodels.Find(modelId);
            Mapper.Map(scalemodel, model);
            model.OwnerId = userId;
            DbContext.StartedScalemodels.Update(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCompletedModelsViewModel>> CompletedAll(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allCompleted = this.Mapper.Map<IEnumerable<AllCompletedModelsViewModel>>(
                this.DbContext.CompletedScalemodels.Where(i => i.OwnerId == user.Id));

            return allCompleted;
        }

        public async Task<IEnumerable<WishlistScalemodelBindingModel>> WishlistAll(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allWishlist = this.Mapper.Map<IEnumerable<WishlistScalemodelBindingModel>>(
                this.DbContext.WishScalemodels.Where(i => i.Userd == user.Id));

            return allWishlist;
        }

        public async Task AddWishAsync(WishlistScalemodelBindingModel scalemodel, string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            CoreValidator.ThrowIfNull(scalemodel);

            scalemodel.UserId = user.Id;

            var model = this.Mapper.Map<WishScalemodel>(scalemodel);
            var biggestNumber = DbContext.WishScalemodels.Where(a => a.Userd == scalemodel.UserId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            model.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;
            user.WishList.Add(model);
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
