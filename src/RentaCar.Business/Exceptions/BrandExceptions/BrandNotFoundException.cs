using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.BrandExceptions
{
    public class BrandNotFoundException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
        public string errorMessage { get; }

        public BrandNotFoundException()
        {
            errorMessage = "Brand yaradila bilmedi";
        }

        public BrandNotFoundException(string message) : base(message)
        {
            errorMessage = message;
        }

        public BrandNotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }
    }
}
