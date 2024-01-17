using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Rent
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public string Status { get; set; }
        [Required]
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public Guid UserAppId { get; set; }
        public UserApp? UserApp { get; set; }
    }
}
