using AssertLibrary;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnaryFunc = System.Func<double, double>;

namespace vychmat4
{
	public partial class Form1 : Form
	{
		private readonly Dictionary<RadioButton, EquationData> equations;

		public Form1()
		{
			InitializeComponent();

			equations = new Dictionary<RadioButton, EquationData>()
			{
				{ funcButton1, new EquationData()
					{
						Equation = (x, y) => x * x - 2 * y,
						CauchySolution = (x0, y0) => x =>  {
							double c = Math.Exp(2*x0) * (y0 - 0.5 * x0 * x0 + 0.5 * x0 - 0.25);
							return c * Math.Exp(-2 * x) + 0.5 * x * x - 0.5 * x + 0.25;
						}
					}
				},

				{ funcButton2, new EquationData()
					{
						Equation = (x, y) => y * Math.Sin(x) / 6,
						CauchySolution = (x0, y0) => x =>  {
							double c = y0 * Math.Exp(Math.Cos(x0) / 6);
							return c * Math.Exp(-Math.Cos(x) / 6);
						}
					}
				},

				{ funcButton3, new EquationData()
					{
						Equation = (x, y) => y * Math.Exp(-x),
						CauchySolution = (x0, y0) => x =>  {
							double c = y0 * Math.Exp(Math.Exp(-x0));
							return c * Math.Exp(-Math.Exp(-x));
						}
					}
				},
			};

			updatePlot();
		}

		private void updatePlot()
		{
			var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
			Assert.IsNotNull(checkedButton);
			EquationData equation = equations[checkedButton];

			double x0 = (double)xUpDown.Value;
			double y0 = (double)yUpDown.Value;
			double xn = (double)xnUpDown.Value;
			double precision = (double)precisionUpDown.Value;

			Assert.IsTrue(xn >= x0);
			Assert.IsPositive(precision);

			UnaryFunc precise = equation.CauchySolution(x0, y0);
			UnaryFunc approx = AdvancedEulerMethod.Solve(equation.Equation, x0, y0, xn, precision);

			drawPlot(precise, approx, x0, xn);
		}

		private void drawPlot(UnaryFunc func, UnaryFunc approx, double x0, double xn)
		{
			//Отступ, чтобы отрезок интерполяции занимал 75% графика (отступы - 12.5% каждый)
			double offset = (xn - x0) * 0.125;
			double left = x0 - offset;
			double right = xn + offset;
			if (left > right)
			{
				double temp = left;
				left = right;
				right = temp;
			}

			var colors = new List<OxyColor> { OxyColors.RoyalBlue, OxyColors.Red };
			var myModel = new PlotModel
			{
				DefaultColors = colors,
				LegendItemAlignment = OxyPlot.HorizontalAlignment.Center,
				LegendPosition = LegendPosition.BottomCenter,
				LegendOrientation = LegendOrientation.Horizontal,
				LegendPlacement = LegendPlacement.Outside,
			};

			var precisePlot = new FunctionSeries(func, left, right, 0.1, "Точное решение");
			var approxPlot = new FunctionSeries(approx, left, right, 0.1, "Приближённое решение");

			myModel.Series.Add(precisePlot);
			myModel.Series.Add(approxPlot);

			plotView1.Model = myModel;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			updatePlot();
		}

		private void xnValidation(object sender, EventArgs e)
		{
			if (xnUpDown.Value <= xUpDown.Value + 1) xnUpDown.Value = xUpDown.Value + 1;
		}
	}
}
