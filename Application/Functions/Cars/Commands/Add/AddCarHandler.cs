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

namespace Application.Functions.Cars.Commands.Add
{
    public class AddCarHandler : IRequestHandler<AddCarCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;
        public AddCarHandler(IMapper mapper, ICarRepository carRepository, ICarModelRepository carModelRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
        }

        public async Task<BaseResponse> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCarValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (!validationResult.IsValid)
            {
                return new BaseResponse(false, "Błąd podczas walidacji danych");
            }

            var car = _mapper.Map<Car>(request);
            car.Image = "test";

            var carModel = await _carModelRepository.GetByIdAsync(request.CarModelId);
            if (carModel == null)
            {
                return new BaseResponse(false, "Brak kategorii o podanym Id");
            }
            car.Image = "Test";
            var addCar = await _carRepository.AddAsync(car);

            if(addCar == null)
            {
                return new BaseResponse(false, "Coś poszło nie tak..");
            }

            return new BaseResponse(true, "Dodano nowy samochód");

            
        }
    }
}
