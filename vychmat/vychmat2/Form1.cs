using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static RectangleMethod.RiemannSum;

namespace RectangleMethod
{ 
    public partial class Form1 : Form
    {
        private struct FunctionData
        {
            public Function Func;
            public Func<double, double, bool> CheckDhs;

            public FunctionData(Function func, Func<double, double, bool> check)
            {
                Func = func;
                CheckDhs = check;
            }
        }

        private Dictionary<RadioButton, FunctionData> functions;
        private Dictionary<RadioButton, FormulaType> formulas;

        public Form1()
        {
            InitializeComponent();

            functions = new Dictionary<RadioButton, FunctionData>() {
                { funcButton1, new FunctionData(x => x * x, (a, b) => true) },
                { funcButton2, new FunctionData(Math.Sqrt,  (a, b) => a >= 0 && b >= 0) },
                { funcButton3, new FunctionData(Math.Log,   (a, b) => a >= 0 && b >= 0) },
                { funcButton4, new FunctionData(Math.Sin,   (a, b) => true) }
            };

            formulas = new Dictionary<RadioButton, FormulaType>() {
                { formulaButton1, FormulaType.Left },
                { formulaButton2, FormulaType.Average },
                { formulaButton3, FormulaType.Right }
            };
        }

        private void startButton_click(object sender, EventArgs e)
        { 
            var activeFunctionButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            var activeFormulaButton  = groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            
            outputBox.Clear();
            


            try
            {
                var funcData = functions[activeFunctionButton];
                double left = (double)aUpDown.Value;
                double right = (double)bUpDown.Value;

                if (!funcData.CheckDhs(left, right))
                    throw new UndefinedFunctionException("функция не определена на заданном отрезке");

                double precision = Math.Pow(10, -(double)precisionUpDown.Value);
                var formula = formulas[activeFormulaButton];

                var result = Calculate(funcData.Func, left, right, precision, formula);

                outputBox.Lines = new string[]
                {
                   $"Значение интеграла: {result.Item1:0.#####}",
                   $"\nКоличество разбиений: {result.Item2}",
                   $"\nПогрешность: {result.Item3:0e-0}"
                };
            }
            catch(Exception ex)
            {
                outputBox.Text = $"Ошибка: {ex.Message}.";
            }
        }
    }
}
