using System.Net;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ReservationDtos;
using RentaCar.Business.Services.Interfaces;

namespace RentaCar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost]
        [Route("create/{carId}")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Create(Guid carId,[FromForm] CreateReservationDto createReservationDto)
        {
            var response = await _reservationService.CreateReservationAsync(carId,createReservationDto);
            return StatusCode((int)HttpStatusCode.OK, new ResponseDTO(response.httpStatusCode, response.Message));

        }
    }
}
