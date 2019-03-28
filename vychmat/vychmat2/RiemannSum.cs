using System;

namespace RectangleMethod
{
    public delegate double Function(double x);
    public delegate double TwoArgFunction(double x, double y);

    public class UndefinedFunctionException : Exception
    {
        public UndefinedFunctionException() { }
        public UndefinedFunctionException(string message) : base(message) { }
        public UndefinedFunctionException(string message, Exception inner) : base(message, inner) { }
    }

    public static class RiemannSum
    {   
        public enum FormulaType : byte
        {
            Left,
            Average,
            Right
        }
     
        private const int INITIAL_STEP_AMOUNT = 100;
        
        private static double approximateIntegral(TwoArgFunction formula, double a, double b, double step)
        {
            double x, result = 0;

            for (x = a; x <= b; x += step)
                result += formula(x, x + step);

            if(double.IsInfinity(result) || double.IsNaN(result))
				throw new UndefinedFunctionException("Функция не определена на заданном отрезке");

            return result;
        }
        
        //Возвращает значение интеграла, количество разбиений и погрешность
        public static Tuple<double, int, double> Calculate(Function f, double a, double b, double precision, FormulaType formulaType)
        {
            if (f == null) throw new ArgumentNullException("Функция для интегрирования не задана");
            if (a == b) return Tuple.Create(0d, 0, 0d);

            if (a > b) Utils.Swap(ref a, ref b);

            //если в одном из пределов функция не определена, сдвигаем на эпсилон
            if (double.IsInfinity(f(a)) || double.IsNaN(f(a)))
                a += double.Epsilon;
            if (double.IsInfinity(f(b)) || double.IsNaN(f(b)))
                b -= double.Epsilon;

            TwoArgFunction formula = null;   //подберём нужную формулу для вычислений площади сегмента
            switch (formulaType)
            {
                case FormulaType.Left:
                    formula = (a, b) => f(a) * (b - a);
                    break;
                case FormulaType.Right:
                    formula = (a, b) => f(b) * (b - a);
                    break;
                case FormulaType.Average:
                    formula = (a, b) => f((a + b) / 2) * (b - a);
                    break;
            }
            
            const double THETA = 1f / 3;
            double step = (b - a) / INITIAL_STEP_AMOUNT;
            double error = precision;
            double integral_n;

            do
            {
                //вычисляем интегралы с N и 2N шагов
                integral_n = approximateIntegral(formula, a, b, step);
                double integral_2n = approximateIntegral(formula, a, b, step / 2);
                
                error = THETA * Math.Abs(integral_2n - integral_n);

                //если нужная точность не достигнута, уменьшаем шаг в два раза
                if (error >= precision) step /= 2;

            } while(error >= precision);        
            
            return Tuple.Create(integral_n, (int)((b - a) / step), error);
        }
    }
}
