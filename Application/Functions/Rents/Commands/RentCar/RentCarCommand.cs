using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Commands.RentCar
{
    public class RentCarCommand : IRequest<BaseResponse>
    {
        //public DateTime DateFrom { get; set; }
        //public DateTime DateTo{ get; set; }
        public string Status { get; set; } = "InRealization";
        public int CarId{ get; set; }
        //public Guid UserAppId{ get; set; }
    }
}
