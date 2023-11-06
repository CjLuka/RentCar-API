using Application.Contracts.Persistance;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetAvaliable
{
    public class GetAvaliableHandler : IRequestHandler<GetAvaliableQuery, BaseResponse<List<GetAvaliableDto>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetAvaliableHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAvaliableDto>>> Handle(GetAvaliableQuery request, CancellationToken cancellationToken)
        {
            var avaliableCars = await _carRepository.GetAvaliableCars(request.startDate, request.endDate);

            if(avaliableCars == null)
            {
                return new BaseResponse<List<GetAvaliableDto>>(false, "Brak dostepnych samochodow");
            }
            return new BaseResponse<List<GetAvaliableDto>>(_mapper.Map<List<GetAvaliableDto>>(avaliableCars), true);
        }
    }
}
