using AutoMapper;
using SalesWebMVC.Dtos;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Seller, SellersDto>();
            Mapper.CreateMap<SellersDto, Seller>();
        }
    }
}
