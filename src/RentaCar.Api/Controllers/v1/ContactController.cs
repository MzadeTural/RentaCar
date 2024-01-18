using System.Net;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ContactDtos;
using RentaCar.Business.Services.Interfaces;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        [Route("create")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateContactDto createContactDto)
        {
            var response = await _contactService.CreateContactAsync(createContactDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
    }
}
