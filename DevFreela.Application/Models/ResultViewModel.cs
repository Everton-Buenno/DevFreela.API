using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Error(string message)
          => new( false, message);

        public static ResultViewModel Sucess( )
      => new();
    }
    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true,string message = ""):base(isSuccess,message)
        {
            Data = data;
        }
        public T? Data { get; private set; }

        public static ResultViewModel<T> Sucess(T data)
            => new ResultViewModel<T>(data);

        public static ResultViewModel<T> Error(string message)
            => new (default, false, message);
    }
}
