using System;

namespace Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string numberOfRaceCar = Console.ReadLine();

            char[,] matrix = new char[size, size];

            int carRow = 0;
            int carCol = 0;

            int traveledKilometers = 0;
            bool isCarGotToTheFinish = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char[] inputLines = new char[matrix.GetLength(1)];
                for (int i = 0; i < input.Length; i++)
                {
                    inputLines[i] = char.Parse(input[i]);
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLines[col];
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        carRow--;
                        break;
                    case "down":
                        carRow++;
                        break;
                    case "left":
                        carCol--;
                        break;
                    case "right":
                        carCol++;
                        break;
                }
                if (matrix[carRow,carCol] == '.')
                {
                    traveledKilometers += 10;
                }
                if (matrix[carRow, carCol] == 'T')
                {
                    traveledKilometers += 30;
                    matrix[carRow, carCol] = '.';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'T')
                            {
                                carRow = row;
                                carCol = col;
                            }
                        }
                    }
                    matrix[carRow, carCol] = '.';
                }
                if (matrix[carRow, carCol] == 'F')
                {
                    
                    traveledKilometers += 10;
                    isCarGotToTheFinish = true;
                    break;
                }
            }
            matrix[carRow, carCol] = 'C';
            if (isCarGotToTheFinish)
            {
                Console.WriteLine($"Racing car {numberOfRaceCar} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {numberOfRaceCar} DNF.");
            }
            Console.WriteLine($"Distance covered {traveledKilometers} km.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
