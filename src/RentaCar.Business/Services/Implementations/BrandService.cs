using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.Exceptions.BrandExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;

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
        public async Task<bool> CreateBrandAsync(CreateBrandDto brand)
        {
            string file = await _fileService.CreateFileAsync(brand.Icon, _environment.WebRootPath + "/uploads/brands/");
            var new_brand = _mapper.Map<Brand>(brand);
            new_brand.IconUrl = file;
            await _brandRepository.CreateAsync(new_brand);
            await _brandRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateBrandAsync(Guid id, UpdateBrandDto brand)
        {
            var model = await _brandRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new BrandNotFoundException();

            if (model.IsDeleted) throw new BrandNotFoundException();

            if (brand.Name != null)
            {
                bool isExist = model.Name.ToLower().Trim() == brand.Name.ToLower().Trim();
                if (isExist)
                {
                    throw new BrandNotFoundException("Name isExist");
                }

                bool isExistDb = await _brandRepository.IsExistAsyncI(x => x.Name == brand.Name);
                if (isExistDb)
                {
                    throw new BrandNotFoundException("Name isExist Database");
                }
                model.Name = brand.Name;
            }
            if (brand.Icon != null)
            {
                string file = await _fileService.CreateFileAsync(brand.Icon, _environment.WebRootPath + "/uploads/brands/");
                model.IconUrl = file;
            }
            _brandRepository.Update(model);
            await _brandRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var model = await _brandRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new BrandNotFoundException();
            if (!model.IsDeleted)
            {
                model.IsDeleted = true;
                _brandRepository.Update(model);
                await _brandRepository.SaveAsync();
                return true;
            }
            throw new BrandNotFoundException();
        }


    }
}
