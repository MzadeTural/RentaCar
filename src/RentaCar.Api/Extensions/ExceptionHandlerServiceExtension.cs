using Microsoft.AspNetCore.Diagnostics;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Exceptions;
using System.Net;

namespace RentaCar.Api.Extensions
{
    public static class ExceptionHandlerServiceExtension
    {
        public static IApplicationBuilder AddExceptionHandler(this IApplicationBuilder application)
        {
            application.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                    string message = feature.Error.Message;

                    if (feature.Error is IBaseException)
                    {
                        var exception = (IBaseException)feature.Error;
                        statusCode = exception.HttpStatusCode;
                        message = exception.errorMessage;
                    }

                    var response = new ResponseDTO(statusCode, message);

                    context.Response.StatusCode = (int)statusCode;
                    await context.Response.WriteAsJsonAsync(response);
                    await context.Response.CompleteAsync();
                });



            });

            return application;
        }
    }
}
