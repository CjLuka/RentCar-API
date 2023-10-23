using Application.Contracts.Persistance;
using Application.Response;
using Application.Services.Interface;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Queries.GetRentsByUser
{
    public class GetRentsByUserHandler : IRequestHandler<GetRentsByUserQuery, BaseResponse<List<GetRentsByUserDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRentRepository _rentRepository;
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserApp> _userManager;
        public GetRentsByUserHandler(IMapper mapper, IRentRepository repository, UserManager<UserApp> userManager, IUserRepository userRepository, IUserServices userServices)
        {
            _mapper = mapper;
            _rentRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
            _userServices = userServices;
        }

        public async Task<BaseResponse<List<GetRentsByUserDto>>> Handle(GetRentsByUserQuery request, CancellationToken cancellationToken)
        {
            var userName = _userServices.getUserName();
            var user = _userRepository.GetUserByUsernameAsync(userName);

            var data = await _rentRepository.GetByUserIdAsync(user.Result.Id);

            if(data.Count == 0)
            {
                return new BaseResponse<List<GetRentsByUserDto>>(true, "Brak zamówień dla danego użytkownika");
            }

            if (data == null)
            {
                return new BaseResponse<List<GetRentsByUserDto>>(false, "Coś poszło nie tak");
            }

            return new BaseResponse<List<GetRentsByUserDto>>(_mapper.Map<List<GetRentsByUserDto>>(data), true);
        }
    }
}
