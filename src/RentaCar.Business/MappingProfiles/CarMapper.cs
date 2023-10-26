using AutoMapper;
using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.MappingProfiles
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<CreateCarDto, Car>().ForMember(cr => cr.MainPhotoUrl, e => e.Ignore())
                                           .ForMember(cr => cr.Photos, e => e.Ignore())
                                           .ForMember(cr => cr.YearOfManufacture, e => e.Ignore())
                                           .ReverseMap();
        }
    }
}
