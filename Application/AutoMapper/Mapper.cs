using Application.Functions.Auth.Commands.Register;
using Application.Functions.CarModels.Commands.Add;
using Application.Functions.CarModels.Queries.GetAll;
using Application.Functions.Cars.Commands.Add;
using Application.Functions.Cars.Queries.GetAll;
using Application.Functions.Cars.Queries.GetAvaliable;
using Application.Functions.Rents.Commands.RentCar;
using Application.Functions.Rents.Queries.GetRentsByUser;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //Car Queries
            CreateMap<Car, GetAllCarsDto>()
                //.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.CarsModel.BrandName))
                //.ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.CarsModel.ModelName))
                .ForPath(dest => dest.CarModel.BrandName, opt => opt.MapFrom(src => src.CarsModel.BrandName))
                .ForPath(dest => dest.CarModel.ModelName, opt => opt.MapFrom(src => src.CarsModel.ModelName))
                .ReverseMap();

            CreateMap<Car, GetAvaliableDto>()
                .ForPath(dest => dest.CarModel.BrandName, opt => opt.MapFrom(src => src.CarsModel.BrandName))
                .ForPath(dest => dest.CarModel.ModelName, opt => opt.MapFrom(src => src.CarsModel.ModelName))
                .ReverseMap();
            //Car Commands
            CreateMap<Car, AddCarCommand>().ReverseMap();

            //CarModel Queries
            CreateMap<CarModel, GetAllCarModelsDto>().ReverseMap();

            //CarModel Commands
            CreateMap<CarModel, AddCarModelCommand>().ReverseMap();

            //User Commands
            CreateMap<UserApp, RegisterCommand>().ReverseMap();

            //Rent Queries
            CreateMap<GetRentsByUserDto, Rent>()
                .ForPath(dest => dest.Car.CarsModel.BrandName, opt => opt.MapFrom(src => src.BrandName))
                .ForPath(dest => dest.Car.CarsModel.ModelName, opt => opt.MapFrom(src => src.ModelName))
                .ReverseMap();

            //Rent Commands
            CreateMap<Rent, RentCarCommand>().ReverseMap();


        }
    }
}
