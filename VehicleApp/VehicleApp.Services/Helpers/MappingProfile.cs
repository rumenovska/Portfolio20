using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.Domain.Models;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(dest => dest.Expenses, src => src.MapFrom(x => x.Expenses))
                .ForMember(dest => dest.DisplayDate, src => src.Ignore())
                .ReverseMap();

            CreateMap<ExpenceType, ExpenceTypeViewModel>()
                .ForMember(dest => dest.Expenses, src => src.MapFrom(x => x.Expenses))
                .ReverseMap();

            CreateMap<Expence, ExpenceViewModel>()
                .ForMember(dest => dest.ExpenceTypeViewModel, src => src.MapFrom(x => x.ExpenceType))
                .ForMember(dest => dest.Vehicle, src => src.MapFrom(x => x.Vehicle))
                .ReverseMap();
        }
    }
}
