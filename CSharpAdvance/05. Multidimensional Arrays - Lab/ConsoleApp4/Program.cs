using System;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int rows = int.Parse(input.Split(", ")[0]);
        int cols = int.Parse(input.Split(", ")[1]);

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
           int[] fillMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row,col] = fillMatrix[col];
            }
        }
        int sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }
        }
        Console.WriteLine(rows);
        Console.WriteLine(cols);
        Console.WriteLine(sum);
    }
}

