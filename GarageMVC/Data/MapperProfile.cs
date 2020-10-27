﻿using AutoMapper;
using GarageMVC.Models.Entities;
using GarageMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Data
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            //CreateMap<Vehicle, VehicleAddViewModel>();
            CreateMap<Vehicle, VehicleAddViewModel>().ReverseMap();
        }
        
    }
}
