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
            await this.DbContext.SaveChangesAsync();
        }

        public async Task CompletedEditAsync(CompletedScalemodelBindingModel scalemodel, int modelId, string userId)
        {
            var model = DbContext.CompletedScalemodels.Find(modelId);
            Mapper.Map(scalemodel, model);
            model.OwnerId = userId;
            DbContext.CompletedScalemodels.Update(model);
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
