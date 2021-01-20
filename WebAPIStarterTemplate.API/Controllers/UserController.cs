using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIStarterTemplate.API.Ressources;
using WebAPIStarterTemplate.API.Validation;
using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Services;

namespace WebAPIStarterTemplate.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serviceUser;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public UserController(IUserService serviceUser, IMapper mapper,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _serviceUser = serviceUser;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserResource userResource)
        {
            var user = await _serviceUser.Authenticate(userResource.Username, userResource.Password);
            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                 }),
                Expires = DateTime.UtcNow.AddDays(7), //token expire after 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserResource userResource)
        {
            // validation
            var validation = new SaveUserResourceValidation();
            var validationResult = await validation.ValidateAsync(userResource);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var user = _mapper.Map<UserResource, User>(userResource);
            // mappage
            var userSave = await _serviceUser.Create(user, userResource.Password);
            //send tocken 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });

        }
    }


}
