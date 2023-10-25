using AutoMapper;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.UserDtos;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.MappingProfiles
{
    public class BrandMapper:Profile
    {
        public BrandMapper()
        {
            CreateMap<CreateBrandDto, Brand>().ForMember(usc => usc.IconUrl, e => e.Ignore())
                .ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ForMember(usc => usc.Icon, e => e.Ignore())
             .ReverseMap();
        }
       
    }
}
