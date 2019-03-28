using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static gaussMethod.Program;

namespace gaussMethod
{
	public struct Matrix
	{
		private double[,] contents;
		public int Width => contents.GetLength(0);
		public int Height => contents.GetLength(1);

		private Matrix(double[,] contents)
		{
			this.contents = contents;
		}
		public static Matrix Parse(string input, int height)
		{
			int width = height + 1;	
			var result = new double[width, height];
			
			var elements = input.Split(new char[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

			if (elements.Any(n => !Regex.IsMatch(n, @"(0|[1-9]\d*)(.\d+)?")))
				ThrowError("некорректный формат файла", 1);
			if (elements.Length != width * height) 
				ThrowError("неподходящее количество элементов", 2);
			
			for (int row = 0; row < height; row++)
			{
				for (int col = 0; col < width; col++)
				{
					result[col, row] = double.Parse(elements[col + row * width]);
				}
			}
			
			return new Matrix(result);
		}
		public static Matrix ReadFromFile(string path, int varAmount)
		{
			using (FileStream stream = File.OpenRead(path))
			{
				using (var reader = new StreamReader(stream))
				{
					return Parse(reader.ReadToEnd(), varAmount);
				}
			}
		}
		
		public void AddRow(int srcRow, int destRow, double mult)
		{
			for (int col = 0; col < Width; col++)
				this[col, destRow] = this[col, destRow] + this[col, srcRow] * mult;
		}
		
		public bool IsTriangular
		{
			get
			{ 
				//по оси Х нет смысла идти дальше размера наим. измерения, т.к. диагональ заканчивается
				for (int col = 0; col < Math.Min(Width, Height) - 1; col++)
				{
					//проверяем все элементы под диагональю. Если есть ненулевые, матрица не треугольная
					for (int row = col + 1; row < Height; row++)
					{
						if (!CompareReal(this[col, row], 0)) return false;
					}
				}
				
				return true;
			}
		}
		
		public double Determinant
		{
			get
			{
				if (Width != Height) return baseMatrix.Determinant;

				if (Width == 2) return (this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0]);

				double det = 0;
				for (int n = 0; n < Width; n++)
					det += this[n, 0] * getMinor(n, 0) * Math.Pow(-1, n % 2);

				return det;
			}
		}

		private Matrix baseMatrix
		{
			get
			{
				int size = Math.Min(Width, Height);
				var baseContents = new double[size, size];
				for (int row = 0; row < size; row++)
				{
					for (int col = 0; col < size; col++)
					{
						baseContents[col, row] = this[col, row];
					}
				}
				
				return new Matrix(baseContents);
			}
		}

		private double getMinor(int excludedCol, int excludedRow)
		{
			Debug.Assert(Width == Height);
			
			var minorMatrix = new Matrix(new double[Width - 1, Width - 1]);

			int targetRow = 0, targetCol = 0;
			for (int srcRow = 0; srcRow < Width; srcRow++)
			{
				//пропускаем "вычеркнутую" строку
				if (srcRow == excludedRow) continue;
				
				for (int srcCol = 0; srcCol < Height; srcCol++)
				{
					//пропускаем "вычеркнутый" столбец
					if (srcCol == excludedCol) continue;

					minorMatrix[targetCol, targetRow] = this[srcCol, srcRow];	
					targetCol++;
				}

				targetRow++;
				targetCol = 0;
			}

			return minorMatrix.Determinant;
		}

		//невязка решения
		public decimal[] GetError(double[] solution)
		{
			var result = new decimal[Height];
			for (int y = 0; y < Height; y++)
			{
				decimal sum = 0;
				
				for (int x = y; x < Width - 1; x++)
					sum += (decimal)(this[x, y] * solution[x]);

				result[y] = sum - (decimal)this[Width - 1, y];
			}

			return result;
		}

		public void Print()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Console.Write($"{this[x, y],-12:0.###}");
					if (x == Width - 1) Console.WriteLine();
				}
			}
		}
		
		public double this[int col, int row]
		{
			get => contents[col, row];
			set => contents[col, row] = value;
		}
	}
}
