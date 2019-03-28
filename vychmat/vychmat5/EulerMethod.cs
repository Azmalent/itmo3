using AssertLibrary;
using System;
using UnaryFunc = System.Func<double, double>;
using TernaryFunc = System.Func<double, double, double, double>;

namespace vychmat5
{
	public static class EulerMethod
	{
		private static double getY1(double y0, double z0, double step)
		{
			return y0 + step * z0;
		}

		private static double getY2(TernaryFunc f, double x0, double y0, double z0, double step)
		{
			double y1 = y0 + step * z0;
			double z1 = z0 + step * f(x0, y0, z0);
			double deltaY = step * z1;
			return y1 + deltaY;
		}

		//Получение массива точек для интерполяции
		private static Point[] approximate(TernaryFunc f, double x0, double y0, double z0, double xn, double step)
		{
			Assert.IsNotNull(f);
			Assert.IsPositive(step);
			Assert.IsMore(xn, x0);

			int stepCount = (int)((xn - x0) / step);

			var points = new Point[stepCount + 1];
			points[0] = new Point(x0, y0);

			double xi = x0, yi = y0, zi = z0;
			for (int i = 1; i <= stepCount; i++)
			{
				double deltaY = step * zi;
				zi += step * f(xi, yi, zi);
				yi += deltaY;
				xi += step;
				points[i] = new Point(xi, yi);
			}

			return points;
		}

		public static UnaryFunc Solve(TernaryFunc f, double x0, double y0, double z0, double xn, double precision)
		{
			if (f == null) throw new ArgumentNullException("функция не определена");
			if (xn <= x0) throw new ArgumentException("xn должен быть больше x0");

			int stepCount = ShootingMethod.STEP_COUNT;
			double step = (xn - x0) / ShootingMethod.STEP_COUNT;
			double error, yn, y2n;
			do
			{
				stepCount *= 2;
				if (stepCount >= 20) break;

				yn = getY1(y0, z0, step);
				step /= 2;
				y2n = getY2(f, x0, y0, z0, step);
				error = Math.Abs(yn - y2n);
			} while (error >= precision);

			Point[] points = approximate(f, x0, y0, z0, xn, step);
			return NewtonMethod.Interpolate(points);
		}
	}
}