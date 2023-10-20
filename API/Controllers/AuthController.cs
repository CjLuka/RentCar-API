using Application.Functions.Auth.Commands.Login;
using Application.Functions.Auth.Commands.Register;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<BaseResponse> Register([FromBody] RegisterCommand request)
        {
            return await _mediator.Send(request);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<BaseResponse<string?>> Login([FromBody] LoginCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
