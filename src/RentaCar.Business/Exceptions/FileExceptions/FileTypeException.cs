using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Exceptions.FileExceptions
{
    public class FileTypeException : Exception, IBaseException
    {
        public HttpStatusCode HttpStatusCode =>HttpStatusCode.UnsupportedMediaType;

        public string errorMessage { get; }
        public FileTypeException(string Message) : base(Message) { errorMessage = Message; }
    }
}
