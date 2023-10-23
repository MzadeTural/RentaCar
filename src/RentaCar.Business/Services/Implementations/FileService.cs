using Microsoft.AspNetCore.Http;
using RentaCar.Business.Exceptions.FileExceptions;
using RentaCar.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Implementations
{
    public class FileService : IFileService
    {
        public async Task<string> CreateFileAsync(IFormFile file, string path)
        {
            if (!file.ContentType.Contains("image/"))
            {
                throw new FileTypeException("Only Images");
            }
            if (file.Length / 1024 > 600)
            {
                throw new FileSizeException("Image too large, you can upload files up to 0.6 MB");
            }
            string FileName = $"{Guid.NewGuid()}-{file.FileName}";
            string ResultPath = Path.Combine(path, FileName);
            using (FileStream fileStream = new FileStream(ResultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return FileName;

        }

        public void DeteleFile(string path)
        {
           if(System.IO.File.Exists(path))
            {
                 System.IO.File.Delete(path);
            }
        }
    }
}
