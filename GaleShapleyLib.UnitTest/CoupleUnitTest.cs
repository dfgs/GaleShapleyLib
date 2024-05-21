using Moq;

namespace GaleShapleyLib.UnitTest
{
	[TestClass]
	public class CoupleUnitTest
	{
		[TestMethod]
		public void ConstructorShouldThrowExceptionIsParameterIsNull()
		{
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Couple<ICandidate>(null, Mock.Of<ICandidate>()));
			Assert.ThrowsException<ArgumentNullException>(() => new Couple<ICandidate>(Mock.Of<ICandidate>(),null));
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}
	}
}