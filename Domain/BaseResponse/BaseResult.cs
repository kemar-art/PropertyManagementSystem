using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseResponse
{
    public class BaseResult<T>
    {
        public Guid Id { get; set; } // Allow setting the Id externally
        public bool IsSuccess { get; private set; }
        public T Value { get; private set; }
        public string Error { get; private set; }

        private BaseResult(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static BaseResult<T> Success(T value)
        {
            return new BaseResult<T>(true, value, null);
        }

        public static BaseResult<T> Failure(string error)
        {
            return new BaseResult<T>(false, default, error);
        }
    }
}
