using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.ModelDtos;
using RentaCar.Core.Entities;

namespace RentaCar.Business.Services.Interfaces
{
	public interface IModelService
	{
        IQueryable<Model> GetAll();
        Task<ResponseDTO> CreateBrandAsync(CreateModelDto model);
        Task<ResponseDTO> UpdateBrandAsync(Guid id, UpdateModelDto model);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}

