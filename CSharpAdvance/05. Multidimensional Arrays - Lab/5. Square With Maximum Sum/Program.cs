using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rowsAndCols = Console.ReadLine();
            int rows = int.Parse(rowsAndCols.Split(", ")[0]);
            int cols = int.Parse(rowsAndCols.Split(", ")[1]);

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sumOfSubmatrix = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int currSumOfSubmatrix = (matrix[row, col] 
                                                + matrix[row, col + 1]
                                                + matrix[row + 1, col] 
                                                + matrix[row + 1, col + 1]);

                    if (sumOfSubmatrix < currSumOfSubmatrix)
                    {
                        sumOfSubmatrix = currSumOfSubmatrix;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[bestRow, bestCol]} {matrix[bestRow, bestCol+1]} \n"+
                              $"{matrix[bestRow+1, bestCol]} {matrix[bestRow+1, bestCol+1]}");
           
            Console.WriteLine($"{sumOfSubmatrix}");



        }
    }
}
