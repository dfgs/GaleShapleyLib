using Moq;

namespace GaleShapleyLib.UnitTest
{
	[TestClass]
	public class ArrayExtensionUnitTest
	{
		[TestMethod]
		public void WhereShouldThrowExceptionIfParameterIsNull()
		{
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.Where((int[])null, t => true).ToArray());
			Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.Where(new int[] { }, null).ToArray());
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
		}


		[TestMethod]
		public void WhereShouldNotReturnIndexedItems()
		{
			int[] items = { 1, 2, 3, 4, 5, 6 };

			var results = items.Where(item => false).ToArray();
			Assert.AreEqual(0, results.Length);
		}
		[TestMethod]
		public void WhereShouldNotReturnAllIndexedItems()
		{
			int[] items = { 1, 2, 3, 4, 5, 6 };

			var results = items.Where(item => true).ToArray();
			Assert.AreEqual(6, results.Length);

			Assert.AreEqual(0, results[0].Index);
			Assert.AreEqual(1, results[1].Index);
			Assert.AreEqual(2, results[2].Index);
			Assert.AreEqual(3, results[3].Index);
			Assert.AreEqual(4, results[4].Index);
			Assert.AreEqual(5, results[5].Index);
		}

		[TestMethod]
		public void WhereShouldReturnIndexedItems()
		{
			int[] items = { 1, 2, 3,4,5,6 };

			var  results = items.Where(item => (item.Item & 1) != 0).ToArray();
			Assert.AreEqual(3, results.Length);

			Assert.AreEqual(0, results[0].Index);
			Assert.AreEqual(1, results[0].Item);

			Assert.AreEqual(2, results[1].Index);
			Assert.AreEqual(3, results[1].Item);

			Assert.AreEqual(4, results[2].Index);
			Assert.AreEqual(5, results[2].Item);

		}


		[TestMethod]
		public void MinCostShouldThrowExceptionIfParameterIsNull()
		{
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.MinCost((int[])null, t => 1));
			Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.MinCost(new int[] { }, null));
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
		}


		[TestMethod]
		public void MinCostShouldReturnNullIfItemsAreEmpty()
		{
			(int,int)[] items = { };

			(int, int)? result = items.MinCost(item => item.Item1) ;
			Assert.IsNull(result);
		}

		[TestMethod]
		public void MinCostShouldReturnMinItem()
		{
			(int, string)[] items = { (1,"A"), (0, "B") , (2, "C") };

			(int, string)? result = items.MinCost(item => item.Item1);
			Assert.IsNotNull(result);
			Assert.AreEqual("B", result.Value.Item2);
		}




	}
}