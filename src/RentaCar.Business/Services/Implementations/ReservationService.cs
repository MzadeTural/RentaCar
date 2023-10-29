using System.Net;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ReservationDtos;
using RentaCar.Business.Exceptions.CarExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.Business.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private ICarRepository _carRepository;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private UserManager<AppUser> _userManager;

        public ReservationService(IReservationRepository reservationRepository,
                                  ICarRepository carRepository,
                                  IMapper mapper,
                                  IHttpContextAccessor httpContextAccessor,
                                  UserManager<AppUser> userManager)
        {
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public async Task<ResponseDTO> CreateReservationAsync(Guid carId, CreateReservationDto reservation)
        {
            ArgumentNullException.ThrowIfNull(carId);
            var carModel = await _carRepository.GetSingleAysnc(x => x.Id == carId);
            if (carModel is null) throw new CarNotFoundException("Car is Not Found");

            var newReservation = _mapper.Map<Reservation>(reservation);
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            newReservation.CarId = carId;

            if (Guid.TryParse(userIdString, out Guid userIdGuid)) newReservation.UserId = userIdGuid;
            newReservation.CarId = reservation.CarId;
            var result = await _reservationRepository.CreateAsync(newReservation);
            await _carRepository.SaveAsync();
            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Your application was received. We will get back to you shortly." : "Something went wrong"
                         );
        }
    }
}

