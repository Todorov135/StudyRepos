using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            List<int> listPositions = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
            string cmd = Console.ReadLine();
            while (cmd != "Bloom Bloom Plow")
            {
                string[] positions = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(positions[0]);
                int col = int.Parse(positions[1]);
                if (!isValid(row, col, matrix))
                {
                    cmd = Console.ReadLine();
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                listPositions.Add(row);
                listPositions.Add(col);

                cmd = Console.ReadLine();
            }
            while (listPositions.Any())
            {
                int rowToPlant = listPositions[0];
                listPositions.RemoveAt(0);
                int colToPlant = listPositions[0];
                listPositions.RemoveAt(0);
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == rowToPlant)
                        {
                            
                            matrix[row, col]++;
                        }
                        if (col == colToPlant)
                        {
                            if (row == rowToPlant)
                            {
                                continue;
                            }
                            matrix[row, col]++;

                        }
                    }
                }

            }
            PrintMatrix(matrix);
            

        }



        private static bool isValid(int row, int col, int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
