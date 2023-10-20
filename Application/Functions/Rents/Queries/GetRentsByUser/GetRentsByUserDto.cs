using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Queries.GetRentsByUser
{
    public class GetRentsByUserDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Car Car { get; set; }

    }
}
