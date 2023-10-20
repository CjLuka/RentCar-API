using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CarModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; } 
        public string ModelName { get; set; } 
        public List<Car> Cars { get; set; }
    }
}
