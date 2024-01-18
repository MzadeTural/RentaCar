using AutoMapper;
using RentaCar.Business.DTOs.ContactDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.MappingProfiles
{
	public class ContactMapper : Profile
	{
		public ContactMapper()
		{
            CreateMap<CreateContactDto, Contact>();
        }
	}
}

