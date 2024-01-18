using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ContactDtos;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IContactService
	{
        Task<ResponseDTO> CreateContactAsync(CreateContactDto contact);
    }
}

