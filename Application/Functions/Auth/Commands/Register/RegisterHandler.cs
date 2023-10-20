using Application.Contracts.Persistance;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserApp> _userManager;

        public RegisterHandler(IMapper mapper, IUserRepository userRepository, UserManager<UserApp> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetByEmailAsync(request.Email);
            if (userExist != null)
            {
                return new BaseResponse(false, "This Email is already exist in database");
            }

            var newUser = _mapper.Map<UserApp>(request);


            //utworzenie nowego użytkownika
            var createUser = await _userManager.CreateAsync(newUser, request.Password);

            //przypisanie roli nowemu użytkownikowi
            var addRole = await _userManager.AddToRoleAsync(newUser, "User");

            if (!addRole.Succeeded)
            {
                return new BaseResponse(false, "Error with add role to new user");
            }


            if (createUser.Succeeded)
            {
                return new BaseResponse(true, "User created");
            }
            return new BaseResponse(false, "Something went wrong");
        }
    }
}
