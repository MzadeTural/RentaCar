using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private IFileService _fileService;
        private IWebHostEnvironment _environment;
        private IMapper _mapper;
        private IBrandRepository _brandRepository;

        public BrandService(IFileService fileService, IWebHostEnvironment environment,IMapper mapper,IBrandRepository brandRepository)
        {
            _fileService = fileService;
            _environment = environment;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<bool> CreateBrandAsync(CreateBrandDto brand)
        {
            string file = await _fileService.CreateFileAsync(brand.Icon, _environment.WebRootPath + "/uploads/brands/");
            var new_brand = _mapper.Map<Brand>(brand);
            new_brand.IconUrl = file;
            await _brandRepository.CreateAsync(new_brand);
            await _brandRepository.SaveAsync();
            return true;
        }


        public Task<bool> UpdateBrandAsync(string id, UpdateBrandDto brand)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBrandAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
