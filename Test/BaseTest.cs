using Application.AutoMapper;
using Application.Contracts.Persistance;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Repository;

namespace Test
{
    public class BaseTest
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<ICarRepository> _carRepository;
        protected readonly Mock<ICarModelRepository> _carModelRepository;
        public BaseTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Application.AutoMapper.Mapper>();
            });
            _mapper = configurationProvider.CreateMapper();
            _carModelRepository = CarModelRepositoryMoq.getCarModelRepository();
            _carRepository= CarRepositoryMoq.getCarRepository();
        }
    }
}
