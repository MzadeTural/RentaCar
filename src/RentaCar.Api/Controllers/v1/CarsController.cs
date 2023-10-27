using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Enums;
using RentaCar.Business.Services.Interfaces;
using RentaCar.DataAccess.Repositories.Interfaces;
using System.Net;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{page}")]
        public Task<List<LoadMoreCarDto>> LoadMore(int page) 
        {
           return _carService.LoadMore(page);       
        }
        // GET api/<CarController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CarController>
        [HttpPost]
      //  [Authorize(AuthenticationSchemes = "Bearer", Roles = "Member")]
        public async Task<IActionResult> Create([FromForm] CreateCarDto createCarDto)
        {

            var response = await _carService.CreateCarAsync(createCarDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }

        // PUT api/<CarController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

       
       
    }
}
