using System;
using System.Linq;
using System.Reflection;

namespace Bees
{
    internal class Revolt
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            int numberOfCommnads = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            bool isPlayerWon = false;

            FillMatrix(size, matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            for (int i = 0; i < numberOfCommnads; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                Move(matrix, ref playerRow, ref playerCol, command);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    Move(matrix, ref playerRow, ref playerCol, command);
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    TrapMove(ref playerRow, ref playerCol, command);
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    isPlayerWon = true;
                    break;
                }
            }
            matrix[playerRow, playerCol] = 'f';
            if (isPlayerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }

        private static void TrapMove(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow += 1;
            }
            else if (command == "down")
            {
                playerRow -= 1;
            }
            else if (command == "left")
            {
                playerCol += 1;
            }
            else if (command == "right")
            {
                playerCol -= 1;
            }
        }

        private static void Move(char[,] matrix, ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow -= 1;
                if (!isValid(playerRow, playerCol, matrix))
                {
                    playerRow = matrix.GetLength(0)-1;
                }
            }
            else if (command == "down")
            {
                playerRow += 1;
                if (!isValid(playerRow, playerCol, matrix))
                {
                    playerRow = 0;
                }
            }
            else if (command == "left")
            {
                playerCol -= 1;
                if (!isValid(playerRow, playerCol, matrix))
                {
                    playerCol = matrix.GetLength(1)-1;
                }
            }
            else if (command == "right")
            {
                playerCol += 1;
                if (!isValid(playerRow, playerCol, matrix))
                {
                    playerCol = 0;
                }
            }
        }

        private static bool isValid(int playerRow, int playerCol, char[,] matrix)
        {
            if (playerRow>=0 && playerRow<matrix.GetLength(0)
                && playerCol >= 0 && playerCol<matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void FillMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string stringInput = Console.ReadLine();
                char[] input = stringInput.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
