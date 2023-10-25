using System;
using System.Net;

namespace RentaCar.Business.Exceptions.ModelExceptions
{
	public class ModelAlreadyExistException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.SeeOther;

        public string errorMessage { get; }

        public ModelAlreadyExistException(string message) : base(message)
        {
            errorMessage = message;
        }
    }
}

