using System;

namespace PolynomialInterpolation
{
	public static class NewtonMethod
	{
		//Разделённая разность (k - порядок)
		private static double difference(Func<double, double> f, double x, double h, int k)
		{
			Assert.GreaterOrEqual(k, 0);
			if (k == 0) return f(x);
			return (difference(f, x + h, h, k - 1) - difference(f, x, h, k - 1)) / (h * k);
		}

		public static Polynomial Interpolate(Func<double, double> f, double x0, double step, int nodeCount)
		{
			if (f == null) throw new ArgumentNullException("Функция для интерполяции не задана.");
			if (nodeCount < 2) throw new ArgumentException("Для интерполяции необходимо как минимум два узла.");
			if (Math.Abs(step) < 0.01) throw new ArgumentOutOfRangeException("Шаг не должен быть равен нулю.");

			//Проверка, что функция определена во всех узлах
			double xn = x0;
			for (int i = 0; i < nodeCount; i++)
			{
				double yn = f(xn);
				if (double.IsNaN(yn) || double.IsInfinity(yn))
					throw new ArithmeticException("Функция должна быть определена во всех узлах.");
				xn += step;
			}

			var coefficients = new double[nodeCount];

			for (int i = 0; i < nodeCount; i++)
				coefficients[i] = difference(f, x0, step, i);

			return new Polynomial(coefficients, x0, step);
		}
	}
}
