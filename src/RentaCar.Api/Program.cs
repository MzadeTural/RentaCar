using Microsoft.AspNetCore.Diagnostics;
using RentaCar.Api.Extensions;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.Exceptions;
using RentaCar.Business.Helpers.Settings;
using RentaCar.Business.MappingProfiles;
using RentaCar.Business.Services;

using RentaCar.DataAccess.Repositories;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccesServices();
builder.Services.AddBusinessServices();
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddJwtAuthenticationService(builder.Configuration["Jwt:Audience"], builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:SigningKey"]);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var statusCode = HttpStatusCode.InternalServerError;
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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
