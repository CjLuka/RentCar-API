using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CarModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string BrandName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string ModelName { get; set; } 
        public List<Car> Cars { get; set; }
    }
}
