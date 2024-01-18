using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ContactDtos;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.Business.Services.Implementations
{
	public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<ResponseDTO> CreateContactAsync(CreateContactDto contact)
        {
            var newContact = _mapper.Map<Contact>(contact);
            var result = await _contactRepository.CreateAsync(newContact);
            await _contactRepository.SaveAsync();
            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Your application was received. We will get back to you shortly." : "Something went wrong"
                                   );
        }
    }
}

