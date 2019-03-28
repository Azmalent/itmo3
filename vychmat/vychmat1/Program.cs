using System;
using System.IO;
using System.Linq;
using System.Text;

namespace gaussMethod
{
	internal class Program
	{
		private const double TOLERANCE = 1E-8; 	//для сравнения вещественных чисел с учётом погрешностей
		private const int MAX_VARIABLES = 20;
		private const int STRINGBUILDER_BUFFER = 500;
		
		//================================================================================
		
		private static int currentChoice = 0;
		private static void showMenuOptions()
		{
			Console.Clear();
			Console.WriteLine("Выберите желаемое действие");
			Console.WriteLine((currentChoice == 0 ? "> " : "  ") + "Ввести матрицу через консоль");
			Console.WriteLine((currentChoice == 1 ? "> " : "  ") + "Считать матрицу из файла");
			Console.WriteLine((currentChoice == 2 ? "> " : "  ") + "Выход");
			
			getMenuInput();
		}
		private static void getMenuInput()
		{
			ConsoleKey key;
			do
			{
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.DownArrow:
						if (currentChoice < 2) currentChoice++;
						else currentChoice = 0;
						showMenuOptions();
						break;
						
					case ConsoleKey.UpArrow:
						if (currentChoice > 0) currentChoice--;
						else currentChoice = 2;
						showMenuOptions();
						break;
						
					case ConsoleKey.Enter:
						switch (currentChoice)
						{
								case 0:
									readFromConsole();
									break;
									
								case 1: 
									readFromFile();
									break;
									
								case 2:
									Environment.Exit(0);
									break;
						}
						break;
				}
			} while (key != ConsoleKey.DownArrow && key != ConsoleKey.UpArrow && key != ConsoleKey.Enter);
		}

		private static void readFromConsole()
		{
			int varAmount = inputVariableAmount();
			
			Console.WriteLine("\nЭлементы должны быть разделены пробелами, переносом строки или табуляцией.");
			var builder = new StringBuilder(STRINGBUILDER_BUFFER);

			for (int i = 0; i < varAmount; i++)
			{
				Console.WriteLine($"Введите {i + 1}-ю строку матрицы:");
				builder.Append(Console.ReadLine());
				builder.Append("\n");
			}

			var matrix = Matrix.Parse(builder.ToString(), varAmount);
			solve(matrix);
		}
		private static void readFromFile()
		{
			int varAmount = inputVariableAmount();
			
			Console.WriteLine("\nВведите имя файла:");
			string filename = Console.ReadLine();
			
			if (File.Exists(filename))
			{
				var matrix = Matrix.ReadFromFile(filename, varAmount);
				solve(matrix);
			}
			else ThrowError("файл не найден", 3);
		}
		
		private static int inputVariableAmount()
		{
			Console.Clear();
			
			Console.WriteLine($"Введите количество переменных в системе (от 2 до {MAX_VARIABLES}):");
			int n = 0;
			bool success = false;
			do
			{
				try
				{
					n = int.Parse(Console.ReadLine());
					if (n < 2 || n > MAX_VARIABLES) 
						Console.WriteLine($"Число должно быть в пределах от 2 до {MAX_VARIABLES}.");
					else success = true;
				}
				catch(FormatException) { Console.WriteLine("Некорректный ввод. Попробуйте ещё раз."); }
				
			} while (!success);
			
			return n;
		}
		
		private static void solve(Matrix matrix)
		{
			Console.Clear();
			
			Console.WriteLine("------------ Исходная матрица ------------");
			matrix.Print();
			
			Console.WriteLine($"\nОпределитель: {matrix.Determinant:0.###}");
			
			try
			{
				matrix = GaussMethod.ToTriangular(matrix);
				Console.WriteLine("\n----- Приведение к треугольному виду -----");
				matrix.Print();

				var solution = GaussMethod.Solve(matrix);
				if (solution == null)
					Console.WriteLine("\nСистема несовместна.");
				else
				{
					Console.WriteLine("\nСтолбец неизвестных:");
					Console.Write(string.Join("\n", solution.Select(n => $"{n:0.###}")));

					Console.WriteLine("\nСтолбец невязок:");
					var errors = matrix.GetError(solution);
					Console.Write(string.Join("\n", errors.Select(n => $"{n:0.###e-0}")
					                                      .Select(n => n == "0e0" ? "0" : n)));
				}
			}
			catch (ArgumentException)
			{
				Console.WriteLine("\nРешение методом Гаусса невозможно.");
			}
		}
		
		public static void Main(string[] args)
		{
			showMenuOptions();
			Console.WriteLine("\nНажмите любую клавишу для выхода.");
			Console.ReadKey();
		}
		
		//==============================================================================
		
		public static bool CompareReal(double a, double b) => Math.Abs(a - b) < TOLERANCE;
		public static void ThrowError(string description, int code)
		{
			Console.WriteLine($"\nОшибка: {description}. \nНажмите любую клавишу для выхода.");
			Console.ReadKey();
			Environment.Exit(code);
		}
	}
	
}