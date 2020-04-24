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

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Expenses, src => src.MapFrom(x => x.Expenses))
                .ReverseMap();

            CreateMap<Expenses, ExpenseViewModel>()
                .ForMember(dest => dest.Product, src => src.MapFrom(x => x.Product))
                .ForMember(dest => dest.Vehicle, src => src.MapFrom(x => x.Vehicle))
                .ForMember(dest => dest.TotalCost, src => src.Ignore())
                .ReverseMap();
        }
    }
}
