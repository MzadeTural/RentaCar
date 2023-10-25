using System;
using System.Net;

namespace RentaCar.Business.Exceptions.ModelExceptions
{
	public class ModelNotFoundException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;

        public string errorMessage { get; }

        public ModelNotFoundException(string message) : base(message)
        {
            errorMessage = message;
        }
    }
}

