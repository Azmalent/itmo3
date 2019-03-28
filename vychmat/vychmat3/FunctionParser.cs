using System;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

namespace PolynomialInterpolation
{
	public static class FunctionParser
	{
		public static Func<double, double> CreateFunction(string expression)
		{
			string[] code = {
			  @"using System;
		            
		        namespace UserFunctions
		        {                
		            public class UnaryFunction
		            {                
		                public static double Function(double x)
		                {
		                    return " + expression + @";
		                }
		            }
		        }"
			};

			var provider = new CSharpCodeProvider();
			var parameters = new CompilerParameters();
			parameters.GenerateInMemory = true;
			CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

			try
			{
				var function = results.CompiledAssembly.GetType("UserFunctions.UnaryFunction").GetMethod("Function");
				var del = function.CreateDelegate(typeof(Func<double, double>));
				return del as Func<double, double>;
			}
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException("Ошибка при компиляции введённого выражения.");
			}
		}
	}
}
