using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Scalemodels.Services
{
    public class ScalemodelsService : BaseService, IScalemodelsService
    {
        public ScalemodelsService(ScalemodelWorldContext dbContext, 
            IMapper mapper, 
            UserManager<ScalemodelWorldUser> userManager) 
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task<int> AddScalemodelAsync(string username)
        {
            var user = await this.GetUserByNamedAsync(username);
            //var scalemodel = new AvailableScalemodel()
            //{
            //    Number = 
            //};
            //this.DbContext.Days.Add(day);

            //program.Days.Add(new ProgramDay()
            //{
            //    Day = day
            //});
            //await this.DbContext.SaveChangesAsync();
            //return day.Id;
            return 2;
        }
    }
}
