using System;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Business.Exceptions.BrandExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.Business.Services.Implementations
{
    public class ModelService : IModelService
	{
        private IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        
        public IQueryable<Model> GetAll()
            => _modelRepository.GetAll();

        public async Task<ResponseDTO> CreateBrandAsync(CreateModelDto model)
        {
            bool isExistDb = await _modelRepository.IsExistAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim());
            if (isExistDb)
            {
                throw new ModelAlreadyExistException("Brand name is already exist");
            }
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

