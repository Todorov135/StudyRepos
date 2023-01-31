using System;
using System.Collections.Generic;
using System.Linq;


namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> truffle = new Dictionary<char, int>()
            {
                { 'B',0},
                { 'S',0},
                { 'W',0 }
            };
            int eatenByBoar = 0;

            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (action == "Collect")
                {
                    if (!isValid(row, col, matrix))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    if (matrix[row, col] == 'B' 
                        || matrix[row, col] == 'S' 
                        || matrix[row, col] == 'W')
                    {
                        truffle[matrix[row, col]]++;
                        matrix[row, col] = '-';
                    }

                }
                else if (action == "Wild_Boar")
                {
                    string direction = tokens[3];
                    if (direction == "up")
                    {
                        while (isValid(row, col, matrix))
                        {
                            if (EatenTruffle(row, col, matrix))
                            {
                                matrix[row, col] = '-';
                                eatenByBoar++;
                            }
                            row -= 2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (isValid(row, col, matrix))
                        {
                            if (EatenTruffle(row, col, matrix))
                            {
                                matrix[row, col] = '-';
                                eatenByBoar++;
                            }
                            row += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (isValid(row, col, matrix))
                        {
                            if (EatenTruffle(row, col, matrix))
                            {
                                matrix[row, col] = '-';
                                eatenByBoar++;
                            }
                            col -= 2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (isValid(row, col, matrix))
                        {
                            if (EatenTruffle(row, col, matrix))
                            {
                                matrix[row, col] = '-';
                                eatenByBoar++;
                            }
                            col += 2;
                        }
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {truffle['B']} black, {truffle['S']} summer, and {truffle['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenByBoar} truffles.");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        private static bool EatenTruffle(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] == 'B'
            || matrix[row, col] == 'S'
                         || matrix[row, col] == 'W')
            {
                return true;
            }
            return false;
        }

        static bool isValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
