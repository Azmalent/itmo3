using AssertLibrary;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnaryFunc = System.Func<double, double>;

namespace vychmat5
{
	public partial class Form1 : Form
	{
		private const int MIN_INTERVAL_LENGTH = 1;
		private const int MAX_INTERVAL_LENGTH = 5;

		private readonly Dictionary<RadioButton, BoundaryValueProblem> problems;

		public Form1()
		{
			InitializeComponent();

			problems = new Dictionary<RadioButton, BoundaryValueProblem>()
			{
				{ funcButton1, BoundaryValueProblem.Problem1 },
				{ funcButton2, BoundaryValueProblem.Problem2 },
				{ funcButton3, BoundaryValueProblem.Problem3 } 
			};

			updatePlot();
		}

		private void updatePlot()
		{
			var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
			Assert.IsNotNull(checkedButton);
			var equation = problems[checkedButton].Equation;

			double a = (double) aUpDown.Value;
			double b = (double) bUpDown.Value;
			double ya = (double) yaUpDown.Value;
			double yb = (double) ybUpDown.Value;
			double z1 = 0, z2 = 1;
			double precision = (double) precisionUpDown1.Value;

			var solution = ShootingMethod.Solve(equation, a, b, ya, yb, z1, z2, precision);
			drawPlot(solution, a, b);
		}
		
		private void drawPlot(UnaryFunc func, double x0, double xn)
		{
			//Отступ, чтобы отрезок интерполяции занимал 75% графика (отступы - 12.5% каждый)
			double offset = (xn - x0) * 0.125;
			double left = x0 - offset;
			double right = xn + offset;

			var colors = new List<OxyColor> { OxyColors.Red };
			var myModel = new PlotModel { DefaultColors = colors };

			double step = (xn - x0) / 30;
			var precisePlot = new FunctionSeries(func, left, right, step);

			myModel.Series.Add(precisePlot);

			plotView1.Model = myModel;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			updatePlot();
		}

		private void leftBoundaryChange(object sender, EventArgs e)
		{
			bUpDown.Minimum = aUpDown.Value + MIN_INTERVAL_LENGTH;
			bUpDown.Maximum = aUpDown.Value + MAX_INTERVAL_LENGTH;
		}
	}
}
