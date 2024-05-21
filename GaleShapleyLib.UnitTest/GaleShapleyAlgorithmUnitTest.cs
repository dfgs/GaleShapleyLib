using Moq;

namespace GaleShapleyLib.UnitTest
{
	[TestClass]
	public class GaleShapleyAlgorithmUnitTest
	{
		[TestMethod]
		public void GetCouplesShouldThrowExceptionIsParameterIsNull()
		{
			GaleShapleyAlgorithm gs;

			gs = new GaleShapleyAlgorithm();


#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => gs.GetCouples(null, new ICandidate[] { }, new ICandidate[] { }).ToArray());
			Assert.ThrowsException<ArgumentNullException>(() => gs.GetCouples(Mock.Of<ICostProvider<ICandidate>>(), null, new ICandidate[] { }).ToArray());
			Assert.ThrowsException<ArgumentNullException>(() => gs.GetCouples(Mock.Of<ICostProvider<ICandidate>>(), new ICandidate[] { }, null).ToArray());

			Assert.ThrowsException<ArgumentNullException>(() => gs.GetCouples(null, new ICandidate[] { }).ToArray());
			Assert.ThrowsException<ArgumentNullException>(() => gs.GetCouples( new ICandidate[] { },null).ToArray());
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}

		[TestMethod]
		public void GetCouplesShouldReturnEmptyCouplesIfAIsempty()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate b1, b2, b3;

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			b3 = Mock.Of<ICandidate>();
			Mock.Get(b3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);

			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { }, new ICandidate[] { b1, b2, b3 }).ToArray();
			
			Assert.AreEqual(0,couples.Length);
		}

		[TestMethod]
		public void GetCouplesShouldReturnEmptyCouplesIfBIsempty()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2, a3;

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			a3 = Mock.Of<ICandidate>();
			Mock.Get(a3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);

			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2, a3 }, new ICandidate[] { }).ToArray();

			Assert.AreEqual(0, couples.Length);
		}

		[TestMethod]
		public void GetCouplesShouldReturnCouplesIfBCountIsLower()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2, a3;
			ICandidate b1, b2;

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			a3 = Mock.Of<ICandidate>();
			Mock.Get(a3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);


			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2, a3 }, new ICandidate[] {b1,b2 }).ToArray();

			Assert.AreEqual(2, couples.Length);
		}

		[TestMethod]
		public void GetCouplesShouldReturnCouplesIfACountIsLower()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2;
			ICandidate b1, b2,b3;

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			b3 = Mock.Of<ICandidate>();
			Mock.Get(b3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);


			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2 }, new ICandidate[] { b1, b2,b3 }).ToArray();

			Assert.AreEqual(2, couples.Length);
		}

		[TestMethod]
		public void GetCouplesShouldReturnCouplesBPreference()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2,a3;
			ICandidate b1, b2, b3;
			ICouple<ICandidate>? couple;

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(a1).Setup(m => m.ToString()).Returns("a1");
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(a2).Setup(m => m.ToString()).Returns("a2");
			a3 = Mock.Of<ICandidate>();
			Mock.Get(a3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(a3).Setup(m => m.ToString()).Returns("a3");

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b1).Setup(m => m.GetCost(a3)).Returns(50);
			Mock.Get(b1).Setup(m => m.ToString()).Returns("b1");
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b2).Setup(m => m.GetCost(a2)).Returns(50);
			Mock.Get(b2).Setup(m => m.ToString()).Returns("b2");
			b3 = Mock.Of<ICandidate>();
			Mock.Get(b3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b3).Setup(m => m.GetCost(a1)).Returns(50);
			Mock.Get(b3).Setup(m => m.ToString()).Returns("b3");


			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2,a3 }, new ICandidate[] { b1, b2, b3 }).ToArray();

			Assert.AreEqual(3, couples.Length);

			couple = couples.FirstOrDefault(item => item.A == a1);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b3, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a2);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b2, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a3);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b1, couple.B);
		}

		[TestMethod]
		public void GetCouplesShouldReturnCouplesAPreference()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2, a3;
			ICandidate b1, b2, b3;
			ICouple<ICandidate>? couple;

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(b1).Setup(m => m.ToString()).Returns("b1");
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(b2).Setup(m => m.ToString()).Returns("b2");
			b3 = Mock.Of<ICandidate>();
			Mock.Get(b3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(0);
			Mock.Get(b3).Setup(m => m.ToString()).Returns("b3");

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a1).Setup(m => m.GetCost(b3)).Returns(50);
			Mock.Get(a1).Setup(m => m.ToString()).Returns("a1");
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a2).Setup(m => m.GetCost(b2)).Returns(50);
			Mock.Get(a2).Setup(m => m.ToString()).Returns("a2");
			a3 = Mock.Of<ICandidate>();
			Mock.Get(a3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a3).Setup(m => m.GetCost(b1)).Returns(50);
			Mock.Get(a3).Setup(m => m.ToString()).Returns("a3");



			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2, a3 }, new ICandidate[] { b1, b2, b3 }).ToArray();

			Assert.AreEqual(3, couples.Length);

			couple = couples.FirstOrDefault(item => item.A == a1);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b3, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a2);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b2, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a3);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b1, couple.B);
		}


		[TestMethod]
		public void GetCouplesShouldReturnCouplesABPreference()
		{
			GaleShapleyAlgorithm gs;
			ICouple<ICandidate>[] couples;
			ICandidate a1, a2, a3;
			ICandidate b1, b2, b3;
			ICouple<ICandidate>? couple;

			a1 = Mock.Of<ICandidate>();
			Mock.Get(a1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a1).Setup(m => m.ToString()).Returns("a1");
			a2 = Mock.Of<ICandidate>();
			Mock.Get(a2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a2).Setup(m => m.ToString()).Returns("a2");
			a3 = Mock.Of<ICandidate>();
			Mock.Get(a3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(a3).Setup(m => m.ToString()).Returns("a3");

			b1 = Mock.Of<ICandidate>();
			Mock.Get(b1).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b1).Setup(m => m.ToString()).Returns("b1");
			b2 = Mock.Of<ICandidate>();
			Mock.Get(b2).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b2).Setup(m => m.ToString()).Returns("b2");
			b3 = Mock.Of<ICandidate>();
			Mock.Get(b3).Setup(m => m.GetCost(It.IsAny<ICandidate>())).Returns(100);
			Mock.Get(b3).Setup(m => m.ToString()).Returns("b3");


			Mock.Get(a1).Setup(m => m.GetCost(b1)).Returns(50);
			Mock.Get(a2).Setup(m => m.GetCost(b2)).Returns(50);
			Mock.Get(a3).Setup(m => m.GetCost(b3)).Returns(50);

			Mock.Get(b1).Setup(m => m.GetCost(a3)).Returns(50);
			Mock.Get(b2).Setup(m => m.GetCost(a2)).Returns(50);
			Mock.Get(b3).Setup(m => m.GetCost(a1)).Returns(50);


			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(new ICandidate[] { a1, a2, a3 }, new ICandidate[] { b1, b2, b3 }).ToArray();

			Assert.AreEqual(3, couples.Length);

			couple = couples.FirstOrDefault(item => item.A == a1);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b3, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a2);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b2, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a3);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b1, couple.B);
		}

		[TestMethod]
		public void GetCouplesUsingCostProviderShouldReturnCouplesABPreference()
		{
			GaleShapleyAlgorithm gs;
			ICouple<string>[] couples;
			string a1, a2, a3;
			string b1, b2, b3;
			ICouple<string>? couple;
			ICostProvider<string> costProvider;

			a1 = "a1";
			a2 = "a2";
			a3 = "a3";

			b1 = "b1";
			b2 = "b2";
			b3 = "b3";

			costProvider = Mock.Of<ICostProvider<string>>();
			Mock.Get(costProvider).Setup(m => m.GetCost("a1", It.IsAny<string>())).Returns(100);
			Mock.Get(costProvider).Setup(m => m.GetCost("a2", It.IsAny<string>())).Returns(100);
			Mock.Get(costProvider).Setup(m => m.GetCost("a3", It.IsAny<string>())).Returns(100);

			Mock.Get(costProvider).Setup(m => m.GetCost("b1", It.IsAny<string>())).Returns(100);
			Mock.Get(costProvider).Setup(m => m.GetCost("b2", It.IsAny<string>())).Returns(100);
			Mock.Get(costProvider).Setup(m => m.GetCost("b3", It.IsAny<string>())).Returns(100);

			Mock.Get(costProvider).Setup(m => m.GetCost("a1", "b1")).Returns(50);
			Mock.Get(costProvider).Setup(m => m.GetCost("a2", "b2")).Returns(50);
			Mock.Get(costProvider).Setup(m => m.GetCost("a3", "b3")).Returns(50);

			Mock.Get(costProvider).Setup(m => m.GetCost("b1", "a3")).Returns(50);
			Mock.Get(costProvider).Setup(m => m.GetCost("b2", "a2")).Returns(50);
			Mock.Get(costProvider).Setup(m => m.GetCost("b3", "a1")).Returns(50);


			gs = new GaleShapleyAlgorithm();
			couples = gs.GetCouples(costProvider, new string[] { a1, a2, a3 }, new string[] { b1, b2, b3 }).ToArray();

			Assert.AreEqual(3, couples.Length);

			couple = couples.FirstOrDefault(item => item.A == a1);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b3, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a2);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b2, couple.B);

			couple = couples.FirstOrDefault(item => item.A == a3);
			Assert.IsNotNull(couple); ;
			Assert.AreEqual(b1, couple.B);
		}


	}
}