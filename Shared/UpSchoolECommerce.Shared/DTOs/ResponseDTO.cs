using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchoolECommerce.Shared.DTOs
{
    public class ResponseDTO<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool ISuccesful { get; set; }
        public List<string> Errors { get; set; }

        public static ResponseDTO<T> Success(T data,int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data=data,
                StatusCode=statusCode,
                ISuccesful=true
            };
        }

        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data=default(T),
                StatusCode=statusCode,
                ISuccesful=true
            };
        }
        public static ResponseDTO<T> Fail(List<string> errors,int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors=errors,
                StatusCode=statusCode,
                ISuccesful=false
            };
        }
        public static ResponseDTO<T> Fail(string error,int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors=new List<string>() { error},
                StatusCode=statusCode,
                ISuccesful=false
            };
        }
    }
}
