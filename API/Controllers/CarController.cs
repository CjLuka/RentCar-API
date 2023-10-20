using Application.Functions.Cars.Commands.Add;
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
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("AllCars")]
        public async Task<BaseResponse<List<GetAllCarsDto>>> GetAllCars()
        {
            return await _mediator.Send(new GetAllCarsQuery());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Add")]
        public async Task <BaseResponse> AddCar([FromBody] AddCarCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
