using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response;
using Application.Contracts.Persistance;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Security.Claims;

namespace Application.Functions.Cars.Queries.GetAll
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, BaseResponse<List<GetAllCarsDto>>>
    {
        private readonly ICarRepository _carRepository;
        //private readonly ICarModelRepository _carModelRepository;
        private readonly IMapper _mapper;
        public GetAllCarsHandler(ICarRepository carRepository/*, ICarModelRepository carModelRepository*/, IMapper mapper)
        {
            _carRepository = carRepository;
            //_carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllCarsDto>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var allCars = await _carRepository.GetAllAsync();

            if (allCars.Count == 0 || allCars == null)
            {
                return new BaseResponse<List<GetAllCarsDto>>(false, "brak samochodów");
            }

            return new BaseResponse<List<GetAllCarsDto>>(_mapper.Map<List<GetAllCarsDto>>(allCars), true);
        }
    }
}
