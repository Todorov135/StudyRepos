using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRange = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixRange, matrixRange];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] filling = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = filling[col];
                }
            }
            int primeDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        primeDiagonalSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(primeDiagonalSum);
        }
    }
}
