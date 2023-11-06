using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Queries.GetAvaliable
{
    public class GetAvaliableQuery : IRequest<BaseResponse<List<GetAvaliableDto>>>
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
