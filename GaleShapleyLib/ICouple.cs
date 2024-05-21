using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public interface ICouple<T>
	{
		T A
		{
			get;
		}
		T B 
		{ 
			get; 
		}
		
	}


}
