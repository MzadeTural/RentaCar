using Microsoft.Extensions.Logging;
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

        public Task<List<Car>> LoadMore(int page);
    }
}
