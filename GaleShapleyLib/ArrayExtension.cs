using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapleyLib
{
	public static class ArrayExtension
	{
		public static IEnumerable<(int Index, T Item)> Where<T>(this T[] Items, Func<(int Index, T Item), bool> Predicate)
		{
			if (Items==null) throw new ArgumentNullException(nameof(Items));
			if (Predicate == null) throw new ArgumentNullException(nameof(Predicate));

			for (int t=0;t<Items.Length;t++)
			{
				(int index, T Item) item = (t, Items[t]);
				if (Predicate(item)) yield return item;
			}
		}
		public static T? MinCost<T>(this IEnumerable<T> Items, Func<T, int> Predicate)
			where T:struct
		{
			int score;
			int minScore;
			T? minItem;

			if (Items == null) throw new ArgumentNullException(nameof(Items));
			if (Predicate == null) throw new ArgumentNullException(nameof(Predicate));

			minItem = null;//default(T);
			minScore = int.MaxValue;

			foreach(T item in Items)
			{
				score = Predicate(item);

				if (score<minScore)
				{
					minScore = score;
					minItem = item;
				}
			}
			return minItem;
		}

		
	}
}
