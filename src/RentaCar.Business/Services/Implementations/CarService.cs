using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using RentaCar.Business.Exceptions.AuthExceptions;
using Microsoft.AspNetCore.Http;
using RentaCar.Business.Exceptions.UserExceptions;
using Microsoft.AspNetCore.Identity;
using RentaCar.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace RentaCar.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly RentaCarContext _context;

        public CarService(ICarRepository carRepository, IFileService fileService, IWebHostEnvironment environment, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, RentaCarContext context)
        {
            _carRepository = carRepository;
            _fileService = fileService;
            _environment = environment;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }

        public async Task<ResponseDTO> CreateCarAsync(CreateCarDto car)
        {
            string file = await _fileService.CreateFileAsync(car.MainPhotoUrl, _environment.WebRootPath + "/uploads/cars/");
            var newCar = _mapper.Map<Car>(car);
            newCar.MainPhotoUrl = file;
            newCar.Photos = await GetImagesUrlAsync(car);
            newCar.YearOfManufacture = new DateTime(int.Parse(car.YearOfManufacture), 1, 1);


            var result = await _carRepository.CreateAsync(newCar);
            await _carRepository.SaveAsync();

            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Car successfully created" : "Something went wrong"
                         );
        }
        private async Task<List<CarPhoto>> GetImagesUrlAsync(CreateCarDto CreateDto)
        {
            List<CarPhoto> carImagesList = new List<CarPhoto>();
            for (int i = 0; i < CreateDto.Photos.Count(); i++)
            {
                string fileName = await _fileService.CreateFileAsync(CreateDto.Photos[i], _environment.WebRootPath + "/uploads/cars/");
                CarPhoto carImage = new CarPhoto()
                {
                    Url = fileName
                };

                carImagesList.Add(carImage);
            }
            return carImagesList;
        }
        public async Task<List<GetUserCarsDto>> GetUserCar(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);

            var user = _httpContextAccessor?.HttpContext?.User?.Identity;
            var loginUser = await _userManager.FindByIdAsync(userId);
            if (user?.IsAuthenticated == false)
                throw new AuthorizationException("Please log in to view any car.", HttpStatusCode.Unauthorized);
            
            var dbUser = await _userManager.FindByNameAsync(user.Name);
            if (dbUser is null)
                throw new UserNotFoundException(nameof(user.Name), user.Name);

            if (loginUser.UserName != user.Name)        
                throw new AuthorizationException("You did not have permission to access other users' cars", HttpStatusCode.Unauthorized);
            
            var cars = await _carRepository.FindAll(c => c.OwnerId == userId.Trim() 
                                                         && !c.IsDeleted, 1, 5, tracking: false,
                                                         c => c.Model,           
                                                         c => c.Owner,          
                                                         c => c.Model.Brand,    
                                                         c => c.GearBox,         
                                                         c => c.FuelType)
                                                        .ProjectTo<GetUserCarsDto>(_mapper.ConfigurationProvider)
                                                        .ToListAsync();
        
            return cars;
        }

        public Task<ResponseDTO> DeleteCarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> LoadMore(int page)
        {
            _carRepository.FindAll(i => !i.IsDeleted,page,16,tracking:false)
                               .OrderByDescending(e => e.Id)
                               .ToListAsync();
         
            throw new ArgumentOutOfRangeException("Price",
                        "The value must be greater than 0.0");
        }

        public Task<ResponseDTO> UpdateCarAsync(string id, UpdateCarDto car)
        {
            throw new NotImplementedException();
        }
    }
}
