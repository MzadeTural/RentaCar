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

namespace RentaCar.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IFileService fileService, IWebHostEnvironment environment, IMapper mapper)
        {
            _carRepository = carRepository;
            _fileService = fileService;
            _environment = environment;
            _mapper = mapper;
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


        public Task<ResponseDTO> DeleteCarAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> LoadMore(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UpdateCarAsync(string id, UpdateCarDto car)
        {
            throw new NotImplementedException();
        }
    }
}
