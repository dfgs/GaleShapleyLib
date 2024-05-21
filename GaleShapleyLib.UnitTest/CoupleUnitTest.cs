using Moq;

namespace GaleShapleyLib.UnitTest
{
	[TestClass]
	public class CoupleUnitTest
	{
		[TestMethod]
		public void ConstructorShouldThrowExceptionIsParameterIsNull()
		{
#pragma warning disable CS8625 // Impossible de convertir un litt�ral ayant une valeur null en type r�f�rence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Couple<ICandidate>(null, Mock.Of<ICandidate>()));
			Assert.ThrowsException<ArgumentNullException>(() => new Couple<ICandidate>(Mock.Of<ICandidate>(),null));
#pragma warning restore CS8625 // Impossible de convertir un litt�ral ayant une valeur null en type r�f�rence non-nullable.
		}
	}
}