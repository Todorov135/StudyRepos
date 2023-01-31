using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_Score = 10;

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int snakeRow = 0;
            int snakeCol = 0;
            int burrowOneRow = 0;
            int burrowOneCol = 0;
            int burrowTwoRow = 0;
            int burrowTwoCol = 0;
            List<int> burrowPositions = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        burrowPositions.Add(row);
                        burrowPositions.Add(col);
                    }
                   
                }
            }
            if (burrowPositions.Any())
            {
                burrowOneRow = burrowPositions[0];
                burrowOneCol = burrowPositions[1];
                burrowTwoRow = burrowPositions[2];
                burrowTwoCol = burrowPositions[3];
            }
            int foodEaten = 0;
            string command = Console.ReadLine();
            while (true)
            {
                if (foodEaten == MAX_Score)
                {
                    break;
                }
                matrix[snakeRow, snakeCol] = '.';
                if (command == "up")
                {
                    snakeRow -= 1;
                }
                else if (command == "down")
                {
                    snakeRow += 1;
                }
                else if (command == "left")
                {
                    snakeCol -= 1;
                }
                else if (command == "right")
                {
                    snakeCol += 1;
                }
                if (!isValidPosition(snakeRow, snakeCol, matrix))
                {
                    break;
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    if (snakeRow == burrowOneRow && snakeCol == burrowOneCol)
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = burrowTwoRow;
                        snakeCol = burrowTwoCol;
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = burrowOneRow;
                        snakeCol = burrowOneCol;
                    }
                }
                matrix[snakeRow, snakeCol] = 'S';

                command = Console.ReadLine();
            }
            if (foodEaten == MAX_Score)
            {
                Console.WriteLine($"You won! You fed the snake.\r\nFood eaten: {foodEaten}");
            }
            else
            {
                Console.WriteLine($"Game over!\r\nFood eaten: {foodEaten}");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

        }

         static bool isValidPosition(int snakeRow, int snakeCol, char[,] matrix)
        {
            if (snakeRow >= 0 && snakeRow<matrix.GetLength(0)
                && snakeCol>=0 && snakeCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
