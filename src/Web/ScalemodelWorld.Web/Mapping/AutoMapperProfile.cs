using AutoMapper;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;

namespace ScalemodelWorld.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
        }

        private void ConfigureScalemodels()
        {
            this.CreateMap<AddPurchasedScalemodelBindingModel, AvailableScalemodel>()
                .ForMember(m => m.Manifacturer.Name, opt => opt.MapFrom(m=>m.Manifacturer))
                .ForMember(i => i.OwnerId, opt => opt.MapFrom(o => o.OwnerId));
        }
    }
}
