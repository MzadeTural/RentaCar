using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Exceptions.BrandExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;
using System.Net;

namespace RentaCar.Business.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private IFileService _fileService;
        private IWebHostEnvironment _environment;
        private IMapper _mapper;
        private IBrandRepository _brandRepository;

        public BrandService(IFileService fileService, IWebHostEnvironment environment, IMapper mapper, IBrandRepository brandRepository)
        {
            _fileService = fileService;
            _environment = environment;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public IQueryable<Brand> GetAll()
        => _brandRepository.GetAll();
        public async Task<ResponseDTO> CreateBrandAsync(CreateBrandDto brand)
        {

            bool isExistDb = await _brandRepository.IsExistAsync(x => x.Name.ToLower().Trim() == brand.Name.ToLower().Trim());
            if (isExistDb)
            {
                throw new BrandAlreadyExistException("Brand name is already exist");
            }

            string file = await _fileService.CreateFileAsync(brand.Icon, _environment.WebRootPath + "/uploads/brands/");
            var newBrand = _mapper.Map<Brand>(brand);
            newBrand.IconUrl = file;
            var result = await _brandRepository.CreateAsync(newBrand);
            await _brandRepository.SaveAsync();

            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Brand successfully created" : "Something went wrong"
                         );
        }

        public async Task<ResponseDTO> UpdateBrandAsync(Guid id, UpdateBrandDto brand)
        {
            ArgumentNullException.ThrowIfNull(id);
            var model = await _brandRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new BrandNotFoundException("Brand Not Found");
            if (model.IsDeleted) throw new BrandNotFoundException("Brand Not Found");

            if (brand.Name != null)
            {
                bool isExistDb = await _brandRepository.IsExistAsync(x => x.Name.ToLower().Trim() == brand.Name.ToLower().Trim());
                if (isExistDb)
                {
                    throw new BrandAlreadyExistException("Brand name is already exist");
                }
                model = _mapper.Map(brand, model);
            }
            if (brand.Icon != null)
            {
                string file = await _fileService.CreateFileAsync(brand.Icon, _environment.WebRootPath + "/uploads/brands/");
                model.IconUrl = file;
            }
            bool result = _brandRepository.Update(model);
            await _brandRepository.SaveAsync();
            return new ResponseDTO(
                                httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                                Message: result ? "Brand successfully modified" : "Something went wrong"
                                );

        }

        public async Task<ResponseDTO> DeleteBrandAsync(Guid id)
        {
            var brand = await _brandRepository.GetSingleAysnc(x => x.Id == id);
            if (brand is null) throw new BrandNotFoundException("Brand Not Found");

            bool result = _brandRepository.SoftDelete(brand);
            await _brandRepository.SaveAsync();
            return new ResponseDTO(
                               httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                               Message: result ? "Brand successfully deleted" : "Something went wrong"
                               );

        }


    }
}
