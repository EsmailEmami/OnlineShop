using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.Dtos
{
    public class Response
    {
        public Response()
        {

        }

        public Response(object? result = null)
        {
            Result = result;
            Message = "عملیات با موفقیت انجام شد";
        }
        public Response(string message, object? result = null)
        {
            Result = result;
            Message = message;
        }
        public object? Result { get; set; } = null;
        public string Message { get; set; }
    }
}
