using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetAvaliable
{
    public class GetAvaliableDto
    {
        public int Year { get; set; }
        public CarModel CarModel { get; set; }
    }
}
