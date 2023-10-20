using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<BaseResponse>
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassowrd { get; set; }
        public string PhoneNumber { get; set; }
    }
}
