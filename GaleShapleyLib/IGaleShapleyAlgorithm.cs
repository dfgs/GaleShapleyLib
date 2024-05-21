using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public interface IGaleShapleyAlgorithm
	{
		IEnumerable<ICouple<T>> GetCouples<T>(IEnumerable<T> A, IEnumerable<T> B)
			where T : ICandidate;
		IEnumerable<ICouple<T>> GetCouples<T>(ICostProvider<T> CostProvider, IEnumerable<T> A, IEnumerable<T> B);

	}
}
