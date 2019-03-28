using System;
using TernaryFunc = System.Func<double, double, double, double>;

namespace vychmat5
{
	internal class BoundaryValueProblem
	{
		public TernaryFunc Equation;

		public static BoundaryValueProblem Problem1;
		public static BoundaryValueProblem Problem2;
		public static BoundaryValueProblem Problem3;

		public BoundaryValueProblem(TernaryFunc equation)
		{
			Equation = equation;
		}
		
		static BoundaryValueProblem()
		{
			Problem1 = new BoundaryValueProblem((x, y, z) => 2 * y + 8 * x * (9 - x));
			Problem2 = new BoundaryValueProblem((x, y, z) => 2*x + y);
			Problem3 = new BoundaryValueProblem((x, y, z) => z + 3*x);
		}
	}
}
