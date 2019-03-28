using AssertLibrary;
using UnaryFunc = System.Func<double, double>;

namespace vychmat5
{
	internal static class NewtonMethod
	{

		//Разделённая разность (k - порядок)
		private static double difference(Point[] points, int i, int k)
		{
			Assert.IsMore(k, -1);
			if (k == 0) return points[i].Y;
			return (difference(points, i + 1, k - 1) - difference(points, i, k - 1)) / (points[k].X - points[0].X);
		}
		public static UnaryFunc Interpolate(Point[] points)
		{
			int nodeCount = points.Length;
			double step = points[1].X - points[0].X;
			Assert.IsNotNull(points);

			var coefficients = new double[nodeCount];
			for (int i = 0; i < nodeCount; i++)
				coefficients[i] = difference(points, 0, i);

			double Polynomial(double x)
			{
				double sum = 0, product = 1, xn = points[0].X;
				for (int i = 0; i < nodeCount; i++)
				{
					sum += coefficients[i] * product;
					product *= x - xn;
					xn += step;
				}
				return sum;
			}

			return Polynomial;
		}

	}
}
