using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ReservationDtos;
using RentaCar.Business.Enums;
using RentaCar.Business.Exceptions.CarExceptions;
using RentaCar.Business.Exceptions.ReservationExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;
using System.Net;
using System.Security.Claims;

namespace RentaCar.Business.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private ICarRepository _carRepository;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;


        public ReservationService(IReservationRepository reservationRepository,
                                  ICarRepository carRepository,
                                  IMapper mapper,
                                  IHttpContextAccessor httpContextAccessor
                                  )
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }


        public async Task<ResponseDTO> CreateReservationAsync(Guid carId, CreateReservationDto reservation)
        {
            ArgumentNullException.ThrowIfNull(carId);
            var carModel = await _carRepository.GetSingleAysnc(x => x.Id == carId);
            var userIdString = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (carModel is null)
                throw new CarNotFoundException("Car is Not Found");

            if (Guid.TryParse(userIdString, out Guid userIdGuid))
                throw new IdCannotConvertException("Type conversion failed");

            if (carModel.OwnerId == userIdGuid)
                throw new CannotReservationOwnCarException("You cannot reservation your own car");

            var newReservation = _mapper.Map<Reservation>(reservation);
            newReservation.CarId = carId;
            newReservation.UserId = userIdGuid;
            newReservation.CarId = reservation.CarId;
            var result = await _reservationRepository.CreateAsync(newReservation);
            await _carRepository.SaveAsync();
            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Your application was received. We will get back to you shortly." : "Something went wrong"
                                   );
        }

        public IActionResult UpdateReservationStatus(int orderId, [FromBody] ReservationStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}

