using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public interface ICostProvider<T>
	{
		int GetCost(T A, T B);
	}
}
