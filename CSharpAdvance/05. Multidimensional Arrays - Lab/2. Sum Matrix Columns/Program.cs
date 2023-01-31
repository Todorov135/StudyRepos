using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
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
                int[] fillingMatrix = Console.ReadLine().Split().Select(el => int.Parse(el)).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = fillingMatrix[col];
                }

            }
            int[] colSum = new int[cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    colSum[col] += matrix[row, col];
                }

            }

            for (int i = 0; i < colSum.Length ; i++)
            {
                Console.WriteLine(colSum[i]);
            }
        }
    }
}
