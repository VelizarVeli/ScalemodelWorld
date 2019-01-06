using AutoMapper;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

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
            this.CreateMap<AvailableScalemodelBindingModel, AvailableScalemodel>()
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<AvailableScalemodel, AllAvailableModelsViewModel>();

            this.CreateMap<AvailableScalemodel, AvailableScalemodelBindingModel>();

            this.CreateMap<AvailableScalemodel, StartedScalemodel>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            this.CreateMap<AvailableScalemodel, AllStartedModelsViewModel>();

            this.CreateMap<StartedScalemodelBindingModel, StartedScalemodel>()
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<StartedScalemodel, CompletedScalemodel>()
                .ForMember(n => n.Number, opt => opt.Ignore())
                .ForMember(i => i.Id, opt => opt.Ignore());

            this.CreateMap<StartedScalemodel, StartedScalemodelBindingModel>();

            this.CreateMap<CompletedScalemodel, AllCompletedModelsViewModel>();

            this.CreateMap<WishlistScalemodelBindingModel, WishScalemodel>()
                //.ForMember(n => n.Number, opt => opt.Ignore())
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<WishScalemodel, WishlistScalemodelBindingModel>()
                .ForMember(n => n.Number, opt => opt.Ignore());
        }
    }
}
