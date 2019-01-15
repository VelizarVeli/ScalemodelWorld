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
    public class PurchasedScalemodelsService : BaseService, IPurchasedScalemodelsService
    {
        public PurchasedScalemodelsService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<AllPurchasedModelsViewModel>> AllPurchased(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allPurchased = this.Mapper.Map<IEnumerable<AllPurchasedModelsViewModel>>(
                this.DbContext.AvailableScalemodels.Where(i => i.OwnerId == user.Id).OrderBy(a => a.Number));

            return allPurchased;
        }

        public async Task AddPurchasedAsync(PurchasedScalemodelBindingModel scalemodel, string id)
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

        public async Task<PurchasedScalemodelBindingModel> GetPurchasedScalemodelDetailsAsync(int id, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var purchasedModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<PurchasedScalemodelBindingModel>(purchasedModel);

            return scalemodel;
        }

        public async Task StartNewBuildAsync(int id, string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var purchasedModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var started = this.Mapper.Map<StartedScalemodel>(purchasedModel);
            var biggestNumber = DbContext.StartedScalemodels.Where(a => a.OwnerId == userId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            started.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;

            DbContext.StartedScalemodels.Add(started);
            DbContext.AvailableScalemodels.Remove(purchasedModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task PurchasedDeleteAsync(int modelId, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var purchasedModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            this.DbContext.AvailableScalemodels.Remove(purchasedModel);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task PurchasedEditAsync(PurchasedScalemodelBindingModel scalemodel, int modelId, string userId)
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
