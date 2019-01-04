using AutoMapper;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;

namespace ScalemodelWorld.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureScalemodels();
        }

        private void ConfigureScalemodels()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<OuterSource, OuterDest>();
            //    cfg.CreateMap<InnerSource, InnerDest>();
            //});
            //config.AssertConfigurationIsValid();



            this.CreateMap<AddPurchasedScalemodelBindingModel, AvailableScalemodel>()
                .ForMember(m => m.Manifacturer, opt => opt.Ignore())
                //.ForMember(m => m.Manifacturer, opt => opt.Ignore())
                ////.ForMember(i => i.OwnerId, opt => opt.MapFrom(o => o.OwnerId))
                //.ForMember(a => a.AvailableAndPurchasedAftermarkets, opt => opt.Ignore())
                //.ForMember(a => a.Owner, opt => opt.Ignore())
                //.ForMember(a => a.Id, opt => opt.Ignore())
                //.ForMember(a => a.ManifacturerId, opt => opt.Ignore());
                ;
        }
    }
}
