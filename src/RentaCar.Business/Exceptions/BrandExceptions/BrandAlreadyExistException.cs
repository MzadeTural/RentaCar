using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.BrandExceptions
{
    public class BrandAlreadyExistException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.SeeOther;

        public string errorMessage { get; }

        public BrandAlreadyExistException(string Message) : base(Message) { errorMessage = Message; }
    }
}
