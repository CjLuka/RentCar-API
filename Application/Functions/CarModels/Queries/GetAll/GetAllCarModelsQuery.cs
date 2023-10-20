using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.CarModels.Queries.GetAll
{
    public class GetAllCarModelsQuery : IRequest<BaseResponse<List<GetAllCarModelsDto>>>
    {

    }
}
