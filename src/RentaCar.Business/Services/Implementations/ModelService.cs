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
        public async Task<ResponseDTO> UpdateBrandAsync(Guid id, UpdateModelDto model)
        {
            ArgumentNullException.ThrowIfNull(id);
            var dbmodel = await _modelRepository.GetSingleAysnc(x => x.Id == id);
            if (dbmodel is null) throw new ModelNotFoundException("Model Not Found");
            if (dbmodel.IsDeleted) throw new ModelNotFoundException("Model Not Found");

            if (model.Name != null)
            {
                bool isExistDb = await _modelRepository.IsExistAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim());
                if (isExistDb)
                {
                    throw new BrandAlreadyExistException("Brand name is already exist");
                }
                dbmodel = _mapper.Map(model, dbmodel);
            }
            //if (model.BrandId != null)
            //{
            //    dbmodel.BrandId = model.BrandId;
            //}
            bool result = _modelRepository.Update(dbmodel);
            await _modelRepository.SaveAsync();
            return new ResponseDTO(
                                httpStatusCode: result ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                                Message: result ? "Model successfully modified" : "Something went wrong"
                                );
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var model = await _modelRepository.GetSingleAysnc(x => x.Id == id);
            if (model is null) throw new ModelNotFoundException("Model Not Found");
            if (!model.IsDeleted)
            {
                model.IsDeleted = true;
                _modelRepository.Update(model);
                await _modelRepository.SaveAsync();
                return true;
            }
            throw new ModelNotFoundException("Model Not Found");
        }

        
    }
}

