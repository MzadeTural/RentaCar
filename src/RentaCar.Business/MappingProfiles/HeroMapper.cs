using AutoMapper;
using RentaCar.Business.DTOs.HeroDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.MappingProfiles
{
    public class HeroMapper : Profile
    {
        public HeroMapper()
        {
            CreateMap<CreateHeroDto, Hero>();
        }
    }
}
