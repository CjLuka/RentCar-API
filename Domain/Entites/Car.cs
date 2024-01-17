using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1886, 2025)]
        public int Year { get; set; }
        public string Image { get; set; }
        [Required]
        public int CarModelId { get; set; }
        public CarModel CarsModel { get; set; }
    }
}
