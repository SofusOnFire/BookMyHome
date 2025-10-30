using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResultWrapper.ResultSubclasses
{
	public sealed class FailureResult<T> : Result<T>
	{
		public Exception Exception { get; }

		internal FailureResult(T? value, Exception exception) : base(value)
		{
			Exception = exception;
		}
	}
}
