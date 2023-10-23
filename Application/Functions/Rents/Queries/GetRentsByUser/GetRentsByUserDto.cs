using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Queries.GetRentsByUser
{
    public class GetRentsByUserDto
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
