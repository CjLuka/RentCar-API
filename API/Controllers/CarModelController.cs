using Application.Functions.CarModels.Commands.Add;
using Application.Functions.CarModels.Queries.GetAll;
using Application.Functions.Cars.Queries.GetAll;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //[Route("AllCarModels")]
        //public async Task<BaseResponse<List<GetAllCarModelsDto>>> GetAllCarModels()
        //{
        //    return await _mediator.Send(new GetAllCarModelsQuery());
        //}

        [HttpGet]
        [Route("AllCarModels")]
        public async Task<ActionResult<List<GetAllCarModelsDto>>> GetAllCarModels()
        {
            var carModels = await _mediator.Send(new GetAllCarModelsQuery());
            return Ok(carModels.Data);
        }

        //}

        //[Authorize(Roles ="Admin")]
        [HttpPost]
        [Route("AddCarModel")]
        public async Task <BaseResponse> AddCarModel([FromBody] AddCarModelCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
