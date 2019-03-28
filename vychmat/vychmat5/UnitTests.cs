using NUnit.Framework;

namespace vychmat5
{
	internal class UnitTests
	{
		[Test]
		public void ShootingTest()
		{
			var bvp = BoundaryValueProblem.Problem1;
			var f = bvp.Equation;

			double a = 0, b = 9, ya = 0, yb = 0, z0 = 4, z1 = -4;

			var solution = ShootingMethod.Solve(f, a, b, ya, yb, z0, z1, 0.1);

			var approxYb = solution(b);
			Assert.AreEqual(yb, approxYb, 0.001);
		}
	}
}
