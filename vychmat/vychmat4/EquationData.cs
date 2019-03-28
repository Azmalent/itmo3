using BinaryFunc = System.Func<double, double, double>;
using BinaryClosure = System.Func<double, double, System.Func<double, double>>;

namespace vychmat4
{
	class EquationData
	{
		public BinaryFunc Equation;
		public BinaryClosure CauchySolution;

		public EquationData()
		{
		}
	}
}
