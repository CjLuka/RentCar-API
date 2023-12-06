using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data
{
    public class MoqContext
    {
        public List<Car> Cars { get; set; }
        public List<CarModel> CarModels { get; set; }

        public MoqContext()
        {
            CarModels = new List<CarModel>()
            {
                new CarModel
                {
                    Id= 1,
                    BrandName = "Audi",
                    ModelName = "A6"
                },
                new CarModel
                {
                    Id= 2,
                    BrandName = "Audi",
                    ModelName = "A8"
                },
                new CarModel
                {
                    Id= 3,
                    BrandName = "Bmw",
                    ModelName = "E51"
                }
            };

            Cars = new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    CarModelId= 1,
                    Image = "Test",
                    Year = 2000
                },
                new Car()
                {
                    Id = 2,
                    CarModelId= 1,
                    Image = "Test",
                    Year = 2000
                },
                new Car()
                {
                    Id = 3,
                    CarModelId= 1,
                    Image = "Test",
                    Year = 2000
                },
                new Car()
                {
                    Id = 4,
                    CarModelId= 2,
                    Image = "Test",
                    Year = 2000
                },
                new Car()
                {
                    Id = 5,
                    CarModelId= 2,
                    Image = "Test",
                    Year = 2000
                },
                new Car()
                {
                    Id = 6,
                    CarModelId= 3,
                    Image = "Test",
                    Year = 2000
                }
            };
        }
    }
}
