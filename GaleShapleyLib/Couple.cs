using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public class Couple<T> : ICouple<T>
	{
		public required T A
		{
			get;
			init;
		}

		public required	T B
		{
			get;
			init;
		}

		
			

		public Couple()
		{

		}

		[SetsRequiredMembers]
		public Couple(T A,T B)
		{
			if (A == null) throw new ArgumentNullException(nameof(A));
			if (B == null) throw new ArgumentNullException(nameof(B));
			this.A = A; this.B = B;
		}

		public override string ToString()
		{
			return $"{A}<->{B}";
		}

	}
}
