using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows < 1)
        {
            Console.WriteLine("Неверный формат ввода.");
            return;
        }

        Console.Write("Введите количество столбцов матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols < 1)
        {
            Console.WriteLine("Неверный формат ввода.");
            return;
        }

        long numberOfPaths = CalculatePaths(rows, cols);

        Console.WriteLine("Количество путей от левого верхнего угла до правого нижнего через треугольник Паскаля: " + numberOfPaths);
    }

    static long CalculatePaths(int rows, int cols)
    {
        if (rows == 0 || cols == 0)
        {
            return 0;
        }

        long[,] array = new long[rows, cols];

        // Инициализируем первую строку и первый столбец единицами
        for (int i = 0; i < rows; i++)
        {
            array[i, 0] = 1;
        }
        for (int j = 0; j < cols; j++)
        {
            array[0, j] = 1;
        }

        // Заполняем остальные элементы матрицы с использованием формулы
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                array[i, j] = array[i - 1, j] + array[i, j - 1];
            }
        }

        return array[rows - 1, cols - 1];
    }
}