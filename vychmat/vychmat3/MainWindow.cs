using Gtk;
using PolynomialInterpolation;
using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;
using System;

public partial class MainWindow : Gtk.Window
{
	PlotView plotView;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		plotView = new PlotView();
		vbox1.Add(plotView);
		plotView.ShowAll();

		updatePlot();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnButton1Clicked(object sender, EventArgs e)
	{
		updatePlot();
	}

	private void updatePlot()
	{
		try
		{
			var func = FunctionParser.CreateFunction(entry2.Text);
			double x0 = spinbutton3.Value;
			double h = spinbutton4.Value;
			int count = (int)spinbutton5.Value;

			drawPlot(func, x0, h, count);
		}
		catch (Exception e)
		{
			var dialog = new MessageDialog(this,
										   DialogFlags.DestroyWithParent,
										   MessageType.Error,
										   ButtonsType.Close,
										   e.Message);
			dialog.Title = "Ошибка";
			dialog.Run();
			dialog.Destroy();
		}
	}

	private void drawPlot(Func<double, double> func, double x0, double h, int count)
	{
		var polynomial = NewtonMethod.Interpolate(func, x0, h, count);

		//Отступ, чтобы отрезок интерполяции занимал 75% графика (отступы - 12.5% каждый)
		double offsetNodes = count * 0.125;
		double left = x0 - offsetNodes * h;
		double right = x0 + (offsetNodes + count - 1) * h;
		if (left > right)
		{
			double temp = left;
			left = right;
			right = temp;
		}

		var myModel = new PlotModel { Title = "График" };
		myModel.Series.Add(new FunctionSeries(func, left, right, 0.1, "f(x)"));
		myModel.Series.Add(new FunctionSeries(polynomial.ValueAt, left, right, 0.1, "P(x)"));

		var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
		for (int i = 0; i < count; i++)
		{
			double xn = x0 + i * h;
			scatterSeries.Points.Add(new ScatterPoint(xn, func(xn), 5, 255));
		}
		myModel.Series.Add(scatterSeries);

		plotView.Model = myModel;
	}
}