using Application.Functions.CarModels.Queries.GetAll;
using Application.Functions.Cars.Commands.Add;
using Application.Functions.Rents.Commands.RentCar;
using Application.Functions.Rents.Queries.GetRentsByUser;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("GetMyRents")]
        public async Task </*BaseResponse*/ActionResult<List<GetRentsByUserDto>>> GetRentsByUserDto()
        {
            var myRents = await _mediator.Send(new GetRentsByUserQuery());
            return Ok(myRents.Data);
            //return await _mediator.Send(new GetRentsByUserQuery());
        }
        
        [HttpPost]
        [Route("RentCar")]
        public async Task <BaseResponse> RentCar([FromBody] RentCarCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}

