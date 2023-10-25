using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.BrandExceptions
{
    public class BrandCreateException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
        public string errorMessage { get; }

        public BrandCreateException()
        {
            errorMessage = "Can not create Brand";
        }

        public BrandCreateException(string message) : base(message)
        {
            errorMessage = message;
        }

        public BrandCreateException(string message, Exception? innerException) : base(message, innerException)
        {
            errorMessage = message;
        }
    }
}
