using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IModelService
	{
        IQueryable<Model> GetAll();
        Task<ResponseDTO> CreateModelAsync(CreateModelDto model);
        Task<ResponseDTO> UpdateModelAsync(Guid id, UpdateModelDto model);
        Task<bool> DeleteModelAsync(Guid id);
    }
}

