using Application.Contracts.Persistance;
using Domain.Entites;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Repository
{
    public class CarModelRepositoryMoq
    {
        public static Mock<ICarModelRepository> getCarModelRepository()
        {
            var _context = new MoqContext();

            var _carModelRepository = new Mock<ICarModelRepository>();

            _carModelRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(() =>
            {
                return _context.CarModels;
            });

            _carModelRepository.Setup(repo => repo.AddAsync(It.IsAny<CarModel>())).ReturnsAsync((CarModel carModel) => 
            {
                _context.CarModels.Add(carModel);
                return carModel;
            });


            return _carModelRepository;
        }
    }
}
