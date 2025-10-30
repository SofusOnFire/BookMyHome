using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Result<T>
    {
        public ResultType Type { get; }
        private readonly T _value;
        private readonly T? _currentValue;
        public enum ResultType { Success, Conflict, Failure }

        public Result(ResultType type, T value)
        {
            Type = type;
            _value = value;
        }

        public Result(ResultType type, T value, T? currentValue) : this(type, value)
        {
            _currentValue = currentValue;
        }

        public T GetValue()
        {
            return _value;
        }
        public T GetCurrentValue()
        {
            if (Type == ResultType.Conflict)
            {
                return _currentValue!;
            }

            throw new InvalidOperationException();
        }

        public static Result<T> Success(T value)
        {
            var result = new Result<T>(ResultType.Success, value);

            return result;
        }

        public static Result<T> Conflict(T originalValue, T currentValue)
        {
            Result<T> result = new Result<T>(ResultType.Conflict, originalValue, currentValue);

            return result;
        }
    }
}
