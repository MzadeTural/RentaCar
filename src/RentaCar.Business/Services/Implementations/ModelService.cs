using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentaCar.Business.DTOs.BrandDtos;
using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Business.Exceptions.ModelExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;
using System.Net;

namespace RentaCar.Business.Services.Implementations
{
    public class ModelService : IModelService
    {
        private IModelRepository _modelRepository;
        private IMapper _mapper;

        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public IQueryable<Model> GetAll()
            => _modelRepository.GetAll();

        public async Task<ResponseDTO> CreateModelAsync(CreateModelDto model)
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
        public async Task<ResponseDTO> UpdateModelAsync(Guid id, UpdateModelDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            var dbModel = await _modelRepository.GetSingleAysnc(x => x.Id == id);
            if (dbModel is null) throw new ModelNotFoundException("Model Not Found");
            if (dbModel.IsDeleted) throw new ModelNotFoundException("Model Not Found");

            if (model.Name != null)
            {
                bool isExistDb = await _modelRepository.IsExistAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim());
                if (isExistDb)
                {
                    throw new ModelAlreadyExistException("Model name is already exist");
                }
                dbModel.Name = model.Name;
            }
            if (model.BrandId != null)
            {
                dbModel.BrandId = (Guid)model.BrandId;
            }
            var result = _modelRepository.Update(dbModel);
            await _modelRepository.SaveAsync();
            return new ResponseDTO(
                                httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                                Message: result ? "Model successfully modified" : "Something went wrong"
                                );
        }

        public async Task<ResponseDTO> DeleteModelAsync(Guid id)
        {
            var model = await _modelRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new ModelNotFoundException("Model Not Found");
            bool result = _modelRepository.SoftDelete(model);
            await _modelRepository.SaveAsync();
            return new ResponseDTO(
            httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            Message: result ? "Model successfully deleted" : "Something went wrong"
            );
        }

       
    }
}

