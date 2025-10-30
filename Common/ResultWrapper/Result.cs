using Common.ResultWrapper.ResultSubclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResultWrapper
{
	public abstract class Result<T>
	{		
		public T? OrignalValue { get; }

		protected Result(T? orignalValue)
		{
			OrignalValue = orignalValue;
		}

		public static Result<T> Success(T value)
		{
			return new SuccessResult<T>(value);
		}

		public static Result<T> Conflict(T originalValue, T databaseValue)
		{
			return new ConflictResult<T>(originalValue, databaseValue);
		}

		public static Result<T> Failure(T? value, Exception exception)
		{
			return new FailureResult<T>(value, exception);
		}

		public bool IsSuccess { get {return this is SuccessResult<T>;} }
		public bool IsFailure { get { return this is FailureResult<T>; } }
		public bool IsConflict { get { return this is ConflictResult<T>; } }
	}
}
