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

            CreateMap<Car, GetUserCarsDto>()
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner.UserName))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Model.Brand.Name))
            .ForMember(dest => dest.BrandLogo, opt => opt.MapFrom(src => src.Model.Brand.IconUrl))
            .ForMember(dest => dest.GearBox, opt => opt.MapFrom(src => src.GearBox.Name))
            .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType.Name))
            .ReverseMap();

            CreateMap<Car, LoadMoreCarDto>()
           .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))         
           .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Model.Brand.Name))
           .ForMember(dest => dest.MainPhoto, opt => opt.MapFrom(src => src.MainPhotoUrl))
           .ForMember(dest => dest.BrandLogo, opt => opt.MapFrom(src => src.Model.Brand.IconUrl))        
           .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType.Name))
           .ReverseMap();
        }
    }
}
