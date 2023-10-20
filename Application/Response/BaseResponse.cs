using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public BaseResponse(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set;}
        public string? Message { get; set;}
        public T? Data { get; set;}

        public BaseResponse(T data ,bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
        public BaseResponse(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}

