using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResultWrapper.ResultSubclasses
{
	public sealed class SuccessResult<T> : Result<T>
	{
		internal SuccessResult(T orignalValue) : base(orignalValue)
		{
		}
	}
}
