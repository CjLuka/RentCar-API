using Application.Functions.CarModels.Queries.GetAll;
using Application.Functions.Cars.Commands.Add;
using Application.Functions.Cars.Queries.GetAll;
using Application.Functions.Cars.Queries.GetAvaliable;
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
        public async Task</*BaseResponse*/ActionResult<List<GetAllCarsDto>>> GetAllCars()
        {
            var cars = await _mediator.Send(new GetAllCarsQuery());
            return Ok(cars.Data);
            
            //return await _mediator.Send(new GetAllCarsQuery());
        }

        
        [HttpGet]
        [Route("AvailableCars")]
        public async Task</*BaseResponse*/ActionResult<List<GetAvaliableDto>>> GetAvaliableCars(DateTime startDate2, DateTime endDate2)
        {
            var avaliableCars = await _mediator.Send(new GetAvaliableQuery() { endDate = endDate2, startDate = startDate2});
            return Ok(avaliableCars.Data);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task <IActionResult>/*<BaseResponse>*/ AddCar([FromBody] AddCarCommand request)
        {
            //return await _mediator.Send(request);
            var car = await _mediator.Send(request);
            return Ok(car);
        }
    }
}
