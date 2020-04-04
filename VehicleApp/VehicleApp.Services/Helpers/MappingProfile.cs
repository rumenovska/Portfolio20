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
                .ForMember(dest => dest.Orders, src => src.MapFrom(x => x.Orders))
                .ForMember(dest => dest.DisplayDate, src => src.Ignore())
                .ReverseMap();


            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
        }
    }
}
