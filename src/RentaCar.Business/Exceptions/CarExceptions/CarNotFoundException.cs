using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.CarExceptions
{
    public class CarNotFoundException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;

        public string errorMessage { get; }

        public CarNotFoundException(string Message):base(Message) { errorMessage = Message; }
        
    }
}
