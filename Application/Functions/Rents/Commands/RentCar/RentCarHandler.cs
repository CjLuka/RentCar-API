using Application.Contracts.Persistance;
using Application.Response;
using Application.Services.Interface;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Commands.RentCar
{
    public class RentCarHandler : IRequestHandler<RentCarCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;
        public RentCarHandler(IMapper mapper, ICarRepository carRepository, IRentRepository rentRepository, IUserServices userServices, IUserRepository userRepository, ICarModelRepository carModelRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _rentRepository = rentRepository;
            _userServices = userServices;
            _userRepository = userRepository;
            _carModelRepository = carModelRepository;
        }

        public async Task<BaseResponse> Handle(RentCarCommand request, CancellationToken cancellationToken)
        {
            var userName = _userServices.getUserName();
            var user = await _userRepository.GetUserByUsernameAsync(userName);

            //var userIdFromBase = "19E3D4BF-37F2-4ED6-8AE3-8C6EAE9920BE";

            var newRent = _mapper.Map<Rent>(request);
            newRent.Status = "InRealization";
            //newRent.UserAppId = Guid.TryParse(userIdFromBase);


            //SPRAWDZONE I DZIAŁA TO PONIŻEJ
            //string userIdFromBase = "19E3D4BF-37F2-4ED6-8AE3-8C6EAE9920BE"; // Tutaj zastąp "wartość_z_bazy_danych" rzeczywistą wartością string.
            //Guid newRentUserAppId;

            //if (Guid.TryParse(userIdFromBase, out newRentUserAppId))
            //{
            //    // Konwersja zakończona sukcesem, newRentUserAppId zawiera teraz wartość Guid.
            //    newRent.UserAppId = newRentUserAppId;
            //}


            //newRent.DateFrom = DateTime.Now;
            //newRent.DateTo = newRent.DateFrom.AddDays(1);

            var modelCar = await _carRepository.GetByIdAsync(request.CarId);

            if(modelCar == null)
            {
                return new BaseResponse(false, "Brak takiego samochodu");
            }

            var addRent = await _rentRepository.AddAsync(newRent);

            if(addRent == null)
            {
                return new BaseResponse(false, "Coś poszło nie tak");
            }
            return new BaseResponse(true, "Zamówiono samochód");
        }
    }
}
