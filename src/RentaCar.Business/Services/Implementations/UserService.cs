using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Win32;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using RentaCar.Business.DTOs.Common;
using RentaCar.Business.DTOs.MailDtos;
using RentaCar.Business.DTOs.UserDtos;
using RentaCar.Business.Enums;
using RentaCar.Business.Exceptions.UserExceptions;
using RentaCar.Business.Services.Interfaces;
using RentaCar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;



        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator, IMailService mailService, IMapper mapper, IFileService fileService, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
            _mailService = mailService;
            _mapper = mapper;
            _fileService = fileService;
            _environment = environment;
        }
        public async Task<ResponseDTO> CreateAsync(CreateUserDto model)
        {
            string FileName = string.Empty;
                     
                FileName = await _fileService.CreateFileAsync(model.ImageUrl, _environment.WebRootPath + "/uploads/users/");
                var user = _mapper.Map<AppUser>(model);
                 user.ImageUrl = FileName;

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

                string? url = await GetEmailConfirmationLinkAsync(user);
                string body =await GetEmailConfirmationTemplate(url);

                await _mailService.SendEmailAsync(new MailRequestDto { ToEmail = user.Email, Subject = "RentaCar email confirmation for activate account", Body = body });

                var response = new ResponseDTO(httpStatusCode:HttpStatusCode.Created,Message: "User successfully created. To login to your account, please activate your account by clicking on the link sent to your email address.");
                return response;
            }

            throw new UserCreateFailedException(result.Errors);
        }

        public Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenEndDate, int refreshTokenLifeTime)
        {
            throw new NotImplementedException();
        }     
            private async Task<string?> GetEmailConfirmationLinkAsync(AppUser user)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var httpContext = _httpContextAccessor.HttpContext;
            var request = httpContext.Request;
            string? url = _linkGenerator.GetUriByAction(
                httpContext,
                action: "ConfirmEmail",
                controller: "Users",
                values: new { token, email = user.Email },
                scheme: request.Scheme,
                host: request.Host
            );



            return url;
        }
        private async Task<string> GetEmailConfirmationTemplate(string url)
        {
            string path = Path.Combine(_environment.WebRootPath, "templates","EmailConfirmation.html");
            using StreamReader streamReader = new StreamReader(path);
            string result = await streamReader.ReadToEndAsync();
            var body= result.Replace("[Link]", url);
            return body;
        }
    }
}
