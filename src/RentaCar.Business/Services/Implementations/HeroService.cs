using Microsoft.AspNetCore.Hosting;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.HeroDtos;
using RentaCar.Business.Exceptions.BrandExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;
using System.Net;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace RentaCar.Business.Services.Implementations
{
    public class HeroService : IHeroService
    {
        private IHeroRepository _heroRepository;
        private IFileService _fileService;
        private IWebHostEnvironment _environment;

        public HeroService(IFileService fileService, IWebHostEnvironment environment, IHeroRepository heroRepository)
        {
            _fileService = fileService;
            _environment = environment;
            _heroRepository =heroRepository;
        }
        public IQueryable<Hero> GetAll()
        => _heroRepository.GetAll();

        public async Task<ResponseDTO> CreateHeroAsync(CreateHeroDto hero)
        {
            string file = await _fileService.CreateFileAsync(hero.Image, _environment.WebRootPath + "/uploads/heros/");
            Hero newHero = new Hero()
            {
                ImageURL = file,
            };
            var result = await _heroRepository.CreateAsync(newHero);
            await _heroRepository.SaveAsync();

            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Hero successfully created" : "Something went wrong"
                         );
        }

        public async Task<ResponseDTO> UpdateHeroAsync(Guid id, UpdateHeroDto hero)
        {
            ArgumentNullException.ThrowIfNull(id);
            var model = await _heroRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new BrandNotFoundException("Model Not Found");
            if (model.IsDeleted) throw new BrandNotFoundException("Model Not Found");
            string file = await _fileService.CreateFileAsync(hero.Image, _environment.WebRootPath + "/uploads/heros/");
            var result = _heroRepository.Update(model);
            await _heroRepository.SaveAsync();
            return new ResponseDTO(
                                httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                                Message: result ? "Hero successfully modified" : "Something went wrong"
                                );
        }

        public async Task<ResponseDTO> DeleteHeroAsync(Guid id)
        {
            var brand = await _heroRepository.GetSingleAysnc(x => x.Id == id);
            if (brand is null) throw new BrandNotFoundException("Hero Not Found");

            bool result = _heroRepository.SoftDelete(brand);
            await _heroRepository.SaveAsync();
            return new ResponseDTO(
                               httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                               Message: result ? "Hero successfully deleted" : "Something went wrong"
                               );
        }
    }
}
