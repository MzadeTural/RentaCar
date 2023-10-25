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
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserDto, AppUser>()
                .ForMember(usc => usc.ImageUrl, e => e.Ignore())
                .ReverseMap();
            CreateMap<CreateBrandDto, Brand>();
        }
    }
}
