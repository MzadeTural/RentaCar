using System;
using System.Net;
using AutoMapper;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Business.Exceptions.BrandExceptions;
using RentaCar.Business.Exceptions.ModelExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace RentaCar.Business.Services.Implementations
{
    public class ModelService : IModelService
	{
        private IModelRepository _modelRepository;
        private IMapper _mapper;

        public ModelService(IModelRepository modelRepository,IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        
        public IQueryable<Model> GetAll()
            => _modelRepository.GetAll();

        public async Task<ResponseDTO> CreateBrandAsync(CreateModelDto model)
        {
            bool isExistDb = await _modelRepository.IsExistAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim());
            if (isExistDb)
            {
                throw new ModelAlreadyExistException("Model name is already exist");
            }
            var newModel = _mapper.Map<Model>(model);
            var result = await _modelRepository.CreateAsync(newModel);

            await _modelRepository.SaveAsync();

            return new ResponseDTO(
                         httpStatusCode: result ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
                         Message: result ? "Model successfully created" : "Something went wrong"
                         );
        }

        public Task<bool> DeleteBrandAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> UpdateBrandAsync(Guid id, UpdateModelDto model)
        {
            throw new NotImplementedException();
        }
    }
}

