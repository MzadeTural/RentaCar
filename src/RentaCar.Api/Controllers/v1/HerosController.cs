using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.HeroDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Services.Interfaces;
using System.Net;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private IHeroService _heroService;

        public HerosController(IHeroService heroService)
        {
            _heroService = heroService;
        }
        [HttpGet]
        [Route("all")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public IActionResult GetAll()
        {
            var response = _heroService.GetAll();
            return Ok(response);

        }
        [HttpPost]
        [Route("create")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateHeroDto createHeroDto)
        {
            var response = await _heroService.CreateHeroAsync(createHeroDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPut]
        [Route("update/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateHeroDto updateHeroDto)
        {
            var response = await _heroService.UpdateHeroAsync(id, updateHeroDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPatch]
        [Route("delete/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _heroService.DeleteHeroAsync(id);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
    }
}
