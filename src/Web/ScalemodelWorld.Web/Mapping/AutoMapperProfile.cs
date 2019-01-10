using System;
using AutoMapper;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Services.SeedData.Dto;

namespace ScalemodelWorld.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureScalemodels();
            ConfigureSeedDatabase();
        }

        private void ConfigureScalemodels()
        {
            this.CreateMap<PurchasedScalemodelBindingModel, AvailableScalemodel>()
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<AvailableScalemodel, AllPurchasedModelsViewModel>();

            this.CreateMap<AvailableScalemodel, PurchasedScalemodelBindingModel>();

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
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<WishScalemodel, WishlistScalemodelBindingModel>();

            this.CreateMap<CompletedScalemodelBindingModel, CompletedScalemodel>()
                .ForMember(n => n.Number, opt => opt.Ignore());

            this.CreateMap<CompletedScalemodel, CompletedScalemodelBindingModel>();
        }

        private void ConfigureSeedDatabase()
        {
            this.CreateMap<WishScalemodel, WishlistBindingModel>();
            this.CreateMap<WishlistBindingModel, WishScalemodel>();

            this.CreateMap<PurchasedScalemodelDto, AvailableScalemodel>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            this.CreateMap<AvailableScalemodel, PurchasedScalemodelDto>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            this.CreateMap<StartedScalemodelDto, StartedScalemodel>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            this.CreateMap<StartedScalemodel, StartedScalemodelDto>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            this.CreateMap<CompletedScalemodelDto, CompletedScalemodel>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            this.CreateMap<CompletedScalemodel, CompletedScalemodelDto>()
                .ForMember(i => i.Id, opt => opt.Ignore());
        }
    }
}
