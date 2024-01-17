using Application.Contracts.Persistance;
using Application.Response;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserApp> _userManager;

        public LoginHandler(IConfiguration configuration, UserManager<UserApp> userManager, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new LoginDto{
                    Email = null,
                    UserName = null,
                    Token = null,
                    Roles = null,
                    Id = null
                };
            }

            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user?.UserName ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                var logingDto = new LoginDto()
                {
                    Email = request.Email,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token).ToString(),
                    Roles = userRoles.ToList(),
                    Id = user.Id.ToString()
                };

                return logingDto;
            }
            return null;
            
        }
        //ZMIENIONA FUNKCJA ABY ZWRACAC USERNAME I EMAIL, A NIE TYLKO SAM TOKEN^^

        //public async Task<BaseResponse<string?>> Handle(LoginCommand request, CancellationToken cancellationToken)
        //{
        //    var user = await _userRepository.GetByEmailAsync(request.Email);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
        //    {
        //        var userRoles = await _userManager.GetRolesAsync(user);

        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user?.UserName ?? ""),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        };

        //        foreach (var userRole in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //        }

        //        var token = GetToken(authClaims);

        //        return new BaseResponse<string?>(
        //            new JwtSecurityTokenHandler().WriteToken(token).ToString(), true);

        //    }
        //    return new BaseResponse<string?>(false, "Incorrect email or password");
        //}
        private JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
