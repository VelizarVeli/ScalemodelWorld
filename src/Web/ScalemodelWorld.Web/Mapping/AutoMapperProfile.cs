﻿using AutoMapper;
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

            this.CreateMap<AvailableScalemodel, AllModelsViewModel>();

            this.CreateMap<AvailableScalemodel, AvailableScalemodelBindingModel>()
                /*.ForMember(m => m.Manifacturer, opt => opt.Ignore())*/;

            this.CreateMap<AvailableScalemodel, StartedScalemodel>()
                .ForMember(i => i.Id, opt => opt.Ignore());
        }
    }
}