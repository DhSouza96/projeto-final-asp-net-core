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
<<<<<<< HEAD
            Mapper.CreateMap<Seller, SellerDto>();
            Mapper.CreateMap<SellerDto, Seller>();
=======
            Mapper.CreateMap<Seller, SellersDto>();
            Mapper.CreateMap<SellersDto, Seller>();
>>>>>>> b4185984df9c6b4720396beaa859e095c74bcbb3
        }
    }
}
