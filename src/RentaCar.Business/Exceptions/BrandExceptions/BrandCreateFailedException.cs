using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.BrandExceptions
{
    public class BrandCreateFailedException : Exception, IBaseException
    {

        public HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;

        public string errorMessage { get; }

        public BrandCreateFailedException(string Message) : base(Message) { errorMessage = Message; }

      
    }
}
