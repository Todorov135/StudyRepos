using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            char objectToFind = char.Parse(Console.ReadLine());

            int findedRow = 0;
            int findedCol = 0;
            bool isCharThere = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currChar = matrix[row, col];
                    if (currChar == objectToFind)
                    {
                        findedRow = row;
                        findedCol = col;
                        isCharThere = true;
                        Console.WriteLine($"({findedRow}, {findedCol})");
                        return;
                    }
                    
                }
            }
            if (!isCharThere)
            {
                Console.WriteLine($"{objectToFind} does not occur in the matrix");
            }
            
        }
    }
}
