using System;
using AutoMapper;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.MappingProfiles
{
    public class ModelMapper : Profile
	{
		public ModelMapper()
		{
			CreateMap<CreateModelDto, Model>();

            CreateMap<Model, GetBrandModelsDto>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Brand.Models))
           
           .ReverseMap();
        }
	}
}

