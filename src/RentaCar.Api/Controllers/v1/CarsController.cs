using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Enums;
using System.Net;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController()
        {
            
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Member")]
        public async Task<IActionResult> Create([FromBody] string value)
        {

            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(HttpStatusCode.OK, "Car created successefully"));

        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
