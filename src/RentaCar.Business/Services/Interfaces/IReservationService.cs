using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ReservationDtos;
using RentaCar.Business.Enums;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IReservationService
	{
        Task<ResponseDTO> CreateReservationAsync(Guid carId,CreateReservationDto reservation);
        public IActionResult UpdateReservationStatus(int orderId, [FromBody] ReservationStatus newStatus);
    }
}

