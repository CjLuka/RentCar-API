using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rents.Queries.GetRentsByUser
{
    public class GetRentsByUserQuery : IRequest<BaseResponse<List<GetRentsByUserDto>>>
    {
        public string UserId { get; set; }
    }
}
