using System.Net;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Business.Services.Interfaces;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        [Route("all")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public IActionResult GetAll()
        {
            var response = _modelService.GetAll();
            return Ok(response);

        }
        [HttpPost]
        [Route("create")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateModelDto createModelDto)
        {
            var response = await _modelService.CreateModelAsync(createModelDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPut]
        [Route("update/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateModelDto updateModelDto)
        {
            var response = await _modelService.UpdateModelAsync(id, updateModelDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
        [HttpPatch]
        [Route("delete/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _modelService.DeleteModelAsync(id);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
    }
}
