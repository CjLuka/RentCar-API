using Application.Contracts.Persistance;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.CarModels.Queries.GetAll
{
    public class GetAllCarModelsHandler : IRequestHandler<GetAllCarModelsQuery, BaseResponse<List<GetAllCarModelsDto>>>
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly IMapper _mapper;
        public GetAllCarModelsHandler(ICarModelRepository carModelRepository, IMapper mapper)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllCarModelsDto>>> Handle(GetAllCarModelsQuery request, CancellationToken cancellationToken)
        {
            var models = await _carModelRepository.GetAllAsync();
            
            if(models.Count == 0)
            {
                return new BaseResponse<List<GetAllCarModelsDto>>(false, "Brak kategorii w bazie danych");
            }

            return new BaseResponse<List<GetAllCarModelsDto>>(_mapper.Map<List<GetAllCarModelsDto>>(models), true);
        }
    }
}
