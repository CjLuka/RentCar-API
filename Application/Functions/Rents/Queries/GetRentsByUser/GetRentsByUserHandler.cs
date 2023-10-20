using Application.Contracts.Persistance;
using Application.Response;
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
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserApp> _userManager;
        public GetRentsByUserHandler(IMapper mapper, IRentRepository repository, UserManager<UserApp> userManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _rentRepository = repository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<List<GetRentsByUserDto>>> Handle(GetRentsByUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _rentRepository.GetByUserIdAsync(request.Id);

            return new BaseResponse<List<GetRentsByUserDto>>(_mapper.Map<List<GetRentsByUserDto>>(data), true);
        }
    }
}
