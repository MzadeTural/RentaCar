using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ReservationDtos;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IReservationService
	{
        Task<ResponseDTO> CreateReservationAsync(Guid carId,CreateReservationDto reservation);
    }
}

