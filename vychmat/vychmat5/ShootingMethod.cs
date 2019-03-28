using System;
using AssertLibrary;
using UnaryFunc = System.Func<double, double>;
using TernaryFunc = System.Func<double, double, double, double>;

namespace vychmat5
{
	internal static class ShootingMethod
	{
		public const int STEP_COUNT = 3;

		//Возвращает уравнение прямой, проходящей через две точки
		private static UnaryFunc getLineEquation(double x1, double y1, double x2, double y2)
		{
			if (y1 == y2) return x => y1;

			double linearFunc(double x) => (x - x1) / (x2 - x1) * (y2 - y1) + y1;
			Assert.IsEqual(y1, linearFunc(x1));
			Assert.IsEqual(y2, linearFunc(x2));
			return linearFunc;
		}

		//Возвращает значение Y на правой границе отрезка
		private static double getLastY(TernaryFunc f, double x0, double y0, double z0, double xn, double h)
		{
			Assert.IsNotNull(f);

			int stepCount = (int)((xn - x0) / h);

			double xi = x0, yi = y0, zi = z0;
			for (int i = 1; i <= stepCount; i++)
			{
				double deltaY = h * zi;
				zi += h * f(xi, yi, zi);
				yi += deltaY;
				xi += h;
			}

			return yi;
		}
		
		public static UnaryFunc Solve(TernaryFunc f, double a, double b, double ya, double yb, double z1,
			double z2, double precision)
		{
			if (f == null) throw new ArgumentNullException("Функция не определена");
			if (b <= a) throw new ArgumentException("b должно быть больше a");

			double step = (b - a) / STEP_COUNT;

			//Находим Y в точке b при значениях пристрелочного параметра Z и Z + 1
			double try1 = getLastY(f, a, ya, z1, b, step);
			double try2 = getLastY(f, a, ya, z2, b, step);

			//Находим линейную зависимость Z = f( Y(b) )
			UnaryFunc lineFunc = getLineEquation(try1, z1, try2, z2);

			//Находим такое значение Z, что Y(b) = Yb
			double z = lineFunc(yb);
			
			return EulerMethod.Solve(f, a, ya, z, b, precision);
		}
	}
}
