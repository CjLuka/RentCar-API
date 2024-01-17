using Application.Contracts.Persistance;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.CarModels.Commands.Add
{
    public class AddCarModelHandler : IRequestHandler<AddCarModelCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;

        public AddCarModelHandler(IMapper mapper, ICarModelRepository carModelRepository)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
        }

        public async Task<BaseResponse> Handle(AddCarModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCarModelValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new BaseResponse(false, "Błąd podczas walidacji");
            }
            var carModel = _mapper.Map<CarModel>(request);

            var addCarModel = await _carModelRepository.AddAsync(carModel);
            if (addCarModel == null)
            {
                return new BaseResponse(false, "Wystąpił problem z dodaniem nowego modelu samochodu");
            }
            return new BaseResponse(true, "Dodano nowy model samochodu");
        }
    }
}
