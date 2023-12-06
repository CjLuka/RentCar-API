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
    public class CarRepositoryMoq
    {
        public static Mock<ICarRepository> getCarRepository()
        {
            var context = new MoqContext();

            var _carRepository = new Mock<ICarRepository>();

            _carRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(() =>
            {
                return context.Cars;
            });


            return _carRepository;
        }
    }
}
