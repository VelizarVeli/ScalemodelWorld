using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalemodel.Data.Models;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Services.Scalemodels
{
    public class CompletedScalemodelsService : BaseService, ICompletedScalemodelsService
    {
        public CompletedScalemodelsService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<IEnumerable<AllCompletedModelsViewModel>> AllCompleted(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allCompleted = this.Mapper.Map<IEnumerable<AllCompletedModelsViewModel>>(
                this.DbContext.CompletedScalemodels.Where(i => i.OwnerId == user.Id).OrderBy(n => n.Number).ThenBy(fd => fd.FinishingDate));

            return allCompleted;
        }

        public async Task<CompletedScalemodelBindingModel> GetCompletedScalemodelDetailsAsync(int modelId, string ownerId)
        {
            var user = await this.GetUserByIdAsync(ownerId);
            var completedModel = await this.DbContext.CompletedScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<CompletedScalemodelBindingModel>(completedModel);

            return scalemodel;
        }

        public async Task CompletedDeleteAsync(int modelId, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var completedModel = await this.DbContext.CompletedScalemodels.FirstOrDefaultAsync(e => e.Id == modelId && e.OwnerId == user.Id);
            this.DbContext.CompletedScalemodels.Remove(completedModel);
            await UpdateNumber(modelId);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task CompletedEditAsync(CompletedScalemodelBindingModel scalemodel, int modelId, string userId)
        {
            var model = DbContext.CompletedScalemodels.Find(modelId);

            if (model.Number != scalemodel.Number)
            {
                await UpdateNumbersFromEdit(model.Number, scalemodel.Number);
                model.Number = scalemodel.Number;
            }

            Mapper.Map(scalemodel, model);
            model.OwnerId = userId;
            DbContext.CompletedScalemodels.Update(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task UpdateNumber(int deletedNumberValue)
        {
            var deletedModel = DbContext.CompletedScalemodels.FirstOrDefault(i => i.Id == deletedNumberValue);

            var completedModels = DbContext.CompletedScalemodels.Where(a => a.Number > deletedModel.Number).ToList();
            foreach (var model in completedModels)
            {
                model.Number -= 1;
            }
            DbContext.CompletedScalemodels.UpdateRange(completedModels);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task UpdateNumbersFromEdit(int oldNumberValue, int editedNumber)
        {
            if (oldNumberValue > editedNumber)
            {
                var completedModels = DbContext.CompletedScalemodels.Where(a => a.Number >= editedNumber && a.Number < oldNumberValue).ToList();

                foreach (var model in completedModels)
                {
                    model.Number += 1;
                }
                DbContext.CompletedScalemodels.UpdateRange(completedModels);
                await this.DbContext.SaveChangesAsync();
            }
            else
            {
                var completedModels = DbContext.CompletedScalemodels.Where(a => a.Number > oldNumberValue && a.Number <= editedNumber).ToList();
                foreach (var model in completedModels)
                {
                    model.Number -= 1;
                }
                DbContext.CompletedScalemodels.UpdateRange(completedModels);
                await this.DbContext.SaveChangesAsync();
            }
        }
    }
}
