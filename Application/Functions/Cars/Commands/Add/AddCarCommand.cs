using Application.Response;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.Add
{
    public class AddCarCommand : IRequest<BaseResponse>
    {
        public int Year { get; set; }
        //public string Image { get; set; }
        public int CarModelId { get; set; }
    }
}
