using Microsoft.Extensions.Logging;
using RentaCar.Business.DTOs.CarDtos;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Interfaces
{
    public interface ICarService
    {
     
        Task<bool> CreateBlogAsync(CreateCarDto blog);
        Task<bool> UpdateBlogAsync(string id, UpdateCarDto blog);
        Task<bool> DeleteBlogAsync(string id);
        public Task<List<Car>> LoadMore(int page);
    }
}
