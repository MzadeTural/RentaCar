using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> CreateFileAsync(IFormFile file, string path);

        void DeteleFile(string path);
    }
}
