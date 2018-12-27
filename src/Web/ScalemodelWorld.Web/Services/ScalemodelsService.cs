using System.Collections.Generic;
using System.Linq;
using Scalemodels.Models.Scalemodels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Web.Models;
using ScalemodelWorld.Web.Services.Contracts;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.Services
{
    public class ScalemodelsService : IScalemodelService
    {
        private readonly ScalemodelWorldContext dbContext;

        public ScalemodelsService(ScalemodelWorldContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<BaseScalemodelViewModel> All()
        {
            return this.dbContext.StartedScalemodels.Select(e => new BaseScalemodelViewModel()
            {
                Name = e.Name
            }).ToList();
        }

        public void Create(CreateScalemodelViewModel startedModel)
        {
            var scalemodel = new StartedScalemodel
            {
                Name = startedModel.Name,
                Place = startedModel.Place,
                BestCompanyOffer = startedModel.BestCompanyOffer,
                DateOfPurchase = startedModel.DateOfPurchase,
                CombinesWith = startedModel.CombinesWith,
                Comments = startedModel.Comments,
                FactoryNumber = startedModel.FactoryNumber,
                InfoHowTo = startedModel.InfoHowTo,
                Manifacturer = startedModel.Manifacturer
            };

            this.dbContext.Add(scalemodel);
            this.dbContext.SaveChanges();
        }
    }
}
