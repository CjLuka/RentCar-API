using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarsModel { get; set; }
    }
}
