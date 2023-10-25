using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Services.Interfaces;
using System.Net;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [Route("all")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public IActionResult GetAll()
        {
            var response = _brandService.GetAll();
            return Ok(response);

        }
        [HttpPost]
        [Route("create")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateBrandDto createBrandDto)
        {
            var response = await _brandService.CreateBrandAsync(createBrandDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPut]
        [Route("update/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateBrandDto updateBrandDto)
        {
            var response = await _brandService.UpdateBrandAsync(id, updateBrandDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPatch]
        [Route("delete/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _brandService.DeleteBrandAsync(id);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
    }
}
