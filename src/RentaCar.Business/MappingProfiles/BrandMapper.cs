using AutoMapper;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.MappingProfiles
{
    public class BrandMapper:Profile
    {
        public BrandMapper()
        {
            CreateMap<CreateBrandDto, Brand>().ForMember(usc => usc.IconUrl, e => e.Ignore())
                .ReverseMap();
        }
       
    }
}
