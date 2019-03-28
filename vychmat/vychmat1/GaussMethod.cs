using System;
using System.Diagnostics;
using static gaussMethod.Program;

namespace gaussMethod
{
	internal static class GaussMethod
	{
		public static double[] Solve(Matrix matrix)
		{
			if (matrix.Width != matrix.Height + 1) 
				throw new ArgumentException("Система уравнений не подходит для решения методом Гаусса");

			try { if (!matrix.IsTriangular) matrix = ToTriangular(matrix); }
			catch (ArgumentException) { return null; } //систему невозможно привести к ступенчатому виду

			int height = matrix.Height, width = matrix.Width;
			var result = new double[height];
			
			for (int i = height - 1; i >= 0; i--)
			{
				//берём значение из столбца свободных членов
				double unknownValue = matrix[width - 1, i];
				
				//переносим уже известные переменные направо
				for (int j = i + 1; j < width - 1; j++)
					unknownValue -= matrix[j, i] * result[j];
				
				//делим всё на коэф-т перед неизвестным и получаем значение неизвестного
				unknownValue /= matrix[i, i];

				//записываем значение в вектор.
				result[i] = unknownValue;
			}

			return result;
		}
		
		public static Matrix ToTriangular(Matrix matrix)
		{
			for (int i = 0; i < matrix.Height - 1; i++)
			{
				for (int j = i + 1; j < matrix.Height; j++)
				{
					//если находим ненулевой элемент, избавляемся от него путём сложения строк
					if (!CompareReal(matrix[i, i], 0))
					{
						if(!CompareReal(matrix[i, j], 0))
							matrix.AddRow(i, j, -matrix[i, j]/matrix[i, i]);
					}
					else
					{
						//если на главной диагонали 0, систему нельзя решить методом Гаусса. Кидаем исключение.
						throw new ArgumentException("Ведущий элемент равен нулю");
					}
					
				}
			}
			
			Debug.Assert(matrix.IsTriangular);
			
			return matrix;
		}
	}
}