using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public class GaleShapleyAlgorithm: IGaleShapleyAlgorithm
	{
		private IEnumerable<ICouple<T>> GetCouplesInternal<T>((int ManCost, int WomanCost)[,] costs, T[] mens, T[] womens)
		{
			bool[,] offers;
			int?[] couples;
			int? existingCoupledManIndex;

			List<int> menIndicesToProcess;

			(int Index, T) m;
			(int Index, T)? w;
			int existingManCost, manCost;

			offers = new bool[mens.Length, womens.Length];
			couples = new int?[womens.Length];


			menIndicesToProcess = new List<int>();
			for (int i = 0; i < mens.Length; i++) menIndicesToProcess.Add(i);

			// some mens are not in couple
			while (menIndicesToProcess.Count > 0)
			{
				// get man to process
				m = (menIndicesToProcess[0], mens[menIndicesToProcess[0]]);

				// get prefered women 
				w = womens.Where(w => !offers[m.Index, w.Index]).MinCost(w => costs[m.Index, w.Index].WomanCost);

				// no more women in list
				if (w == null) break;

				// create offer
				offers[m.Index, w.Value.Index] = true;

				manCost = costs[m.Index, w.Value.Index].ManCost;

				// check if w is maried
				existingCoupledManIndex = couples[w.Value.Index];
				if (existingCoupledManIndex == null)
				{
					// make new couple
					couples[w.Value.Index] = m.Index;
					menIndicesToProcess.RemoveAt(0);
					continue;
				}
				else
				{
					// compare scores from w point of view
					existingManCost = costs[existingCoupledManIndex.Value, w.Value.Index].ManCost;
					if (manCost < existingManCost)
					{
						//replace old couple
						couples[w.Value.Index] = m.Index;
						menIndicesToProcess.RemoveAt(0);
						menIndicesToProcess.Add(existingCoupledManIndex.Value);
					}
				}
			}

			for (int j = 0; j < womens.Length; j++)
			{
				if (couples[j].HasValue) yield return new Couple<T>(mens[couples[j]!.Value], womens[j]);
			}
		}


		public IEnumerable<ICouple<T>> GetCouples<T>(IEnumerable<T> A, IEnumerable<T> B)
			where T:ICandidate
		{
			T[] mens;
			T[] womens;
			(int ManCost, int WomanCost)[,] costs;

			if (A == null) throw new ArgumentNullException(nameof(A));
			if (B == null) throw new ArgumentNullException(nameof(B));

			mens = A.ToArray();
			womens = B.ToArray();
			
			costs = new (int ManScore, int WomanScore)[mens.Length, womens.Length];
			// precalculate costs
			for (int i = 0; i < mens.Length; i++)
			{
				for (int j = 0; j < womens.Length; j++)
				{
					costs[i, j] = (mens[i].GetCost(womens[j]), womens[j].GetCost(mens[i]));
				}
			}
			return GetCouplesInternal(costs,mens,womens);

		}
		public IEnumerable<ICouple<T>> GetCouples<T>(ICostProvider<T> CostProvider, IEnumerable<T> A, IEnumerable<T> B)
		{
			T[] mens;
			T[] womens;
			(int ManCost, int WomanCost)[,] costs;

			if (CostProvider == null) throw new ArgumentNullException(nameof(CostProvider));
			if (A == null) throw new ArgumentNullException(nameof(A));
			if (B == null) throw new ArgumentNullException(nameof(B));

			mens = A.ToArray();
			womens = B.ToArray();

			costs = new (int ManScore, int WomanScore)[mens.Length, womens.Length];
			// precalculate costs
			for (int i = 0; i < mens.Length; i++)
			{
				for (int j = 0; j < womens.Length; j++)
				{
					costs[i, j] = (CostProvider.GetCost(mens[i], womens[j]), CostProvider.GetCost(womens[j], mens[i]));
				}
			}
			return GetCouplesInternal(costs, mens, womens);

		}

	}
}
