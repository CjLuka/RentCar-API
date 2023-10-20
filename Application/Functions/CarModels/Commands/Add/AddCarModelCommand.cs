using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.CarModels.Commands.Add
{
    public class AddCarModelCommand : IRequest<BaseResponse>
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
