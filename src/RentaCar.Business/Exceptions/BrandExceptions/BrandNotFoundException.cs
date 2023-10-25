using System;
using System.Net;

namespace RentaCar.Business.Exceptions.BrandExceptions
{
	public class BrandNotFoundException: Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;

        public string errorMessage { get; }
        public BrandNotFoundException()
        {
            errorMessage = "Brand Not Found";
        }

        public BrandNotFoundException(string message) : base(message)
        {
            errorMessage = message;
        }
    }
}

