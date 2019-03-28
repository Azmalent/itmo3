namespace PolynomialInterpolation
{
	public class Polynomial
	{
		private double[] coefficients;
		private double firstNode;
		private double step;

		public Polynomial(double[] coefficients, double firstNode, double step)
		{
			this.coefficients = coefficients;
			this.firstNode = firstNode;
			this.step = step;
		}

		public double ValueAt(double x)
		{
			double sum = 0;
			double product = 1;
			for (int i = 0; i < coefficients.Length; i++)
			{
				sum += coefficients[i] * product;
				double xn = firstNode + i * step;
				product *= (x - xn);
			}
			return sum;
		}
	}
}
