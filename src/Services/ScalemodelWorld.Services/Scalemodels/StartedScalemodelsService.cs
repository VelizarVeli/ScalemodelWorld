﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Services.Scalemodels
{
    public class StartedScalemodelsService : BaseService, IStartedScalemodelsService
    {
        public StartedScalemodelsService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<AllStartedModelsViewModel>> AllStarted(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allstarted = this.Mapper.Map<IEnumerable<AllStartedModelsViewModel>>(
                this.DbContext.StartedScalemodels.Where(i => i.OwnerId == user.Id).OrderBy(n => n.Number));

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

        public async Task<PurchasedScalemodelBindingModel> GetPurchasedScalemodelDetailsAsync(int id, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var purchasedModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<PurchasedScalemodelBindingModel>(purchasedModel);

            return scalemodel;
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

            DbContext.CompletedScalemodels.Add(finished);
            DbContext.StartedScalemodels.Remove(startModel);
            await UpdateNumber(id);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartedDeleteAsync(int modelId, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var startedModel = await this.DbContext.StartedScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            this.DbContext.StartedScalemodels.Remove(startedModel);
            await UpdateNumber(modelId);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartedEditAsync(StartedScalemodelBindingModel scalemodel, int modelId, string userId)
        {
            var model = DbContext.StartedScalemodels.Find(modelId);

            if(model.Number != scalemodel.Number)
            {
                await UpdateNumbersFromEdit(model.Number, scalemodel.Number);
                model.Number = scalemodel.Number;
            }

            Mapper.Map(scalemodel, model);
            model.OwnerId = userId;
            DbContext.StartedScalemodels.Update(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task UpdateNumber(int deletedNumberValue)
        {
            var deletedModel = DbContext.StartedScalemodels.FirstOrDefault(i => i.Id == deletedNumberValue);

            var startedModels = DbContext.StartedScalemodels.Where(a => a.Number > deletedModel.Number).ToList();
            foreach (var model in startedModels)
            {
                model.Number -= 1;
            }
            DbContext.StartedScalemodels.UpdateRange(startedModels);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task UpdateNumbersFromEdit(int oldNumberValue, int editedNumber)
        {
            if (oldNumberValue > editedNumber)
            {
                var startedModels = DbContext.StartedScalemodels.Where(a => a.Number >= editedNumber && a.Number < oldNumberValue).ToList();

                foreach (var model in startedModels)
                {
                    model.Number += 1;
                }
                DbContext.StartedScalemodels.UpdateRange(startedModels);
                await this.DbContext.SaveChangesAsync();
            }
            else
            {
                var startedModels = DbContext.StartedScalemodels.Where(a => a.Number > oldNumberValue && a.Number <= editedNumber).ToList();
                foreach (var model in startedModels)
                {
                    model.Number -= 1;
                }
                DbContext.StartedScalemodels.UpdateRange(startedModels);
                await this.DbContext.SaveChangesAsync();
            }
        }
    }
}
