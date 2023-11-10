﻿using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.Login
{
    //public class LoginCommand : IRequest<BaseResponse<string?>>
    //{
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //}
    public class LoginCommand : IRequest<LoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
