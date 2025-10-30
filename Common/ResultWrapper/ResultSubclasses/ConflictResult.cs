using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResultWrapper.ResultSubclasses
{
	public sealed class ConflictResult<T> : Result<T>
	{
		public T DatabaseValue { get; }

		internal ConflictResult(T orignaleValue, T databaseValue) : base(orignaleValue)
		{
			DatabaseValue = databaseValue;
		}
	}
}
