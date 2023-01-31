using System;

namespace Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int life = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int marioRow = 0;
            int marioCol = 0;

            bool isPrincessSaved = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }

            }

            matrix[marioRow][marioCol] = '-';
            while (life > 0)
            {
                int marioPreviosPossitionRow = marioRow;
                int marioPreviosPossitionCol = marioCol;
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0];
                int bowserRow = int.Parse(commands[1]);
                int bowserCol = int.Parse(commands[2]);

                matrix[bowserRow][bowserCol] = 'B';
                switch (direction)
                {
                    case "W":
                        marioRow--;
                        break;
                    case "S":
                        marioRow++;
                        break;
                    case "A":
                        marioCol--;
                        break;
                    case "D":
                        marioCol++;
                        break;
                }
                life--;
                if (!IsInMatrix(marioRow, marioCol, matrix))
                {
                    marioRow = marioPreviosPossitionRow;
                    marioCol = marioPreviosPossitionCol;
                }
                if (matrix[marioRow][marioCol] == 'P')
                {
                    isPrincessSaved = true;
                    matrix[marioRow][marioCol] = '-';
                    break;
                }
                if (matrix[marioRow][marioCol] == 'B')
                {
                    life -= 2;
                    if (life <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        break;
                    }
                    matrix[marioRow][marioCol] = '-';
                }
                if (life<=0)
                {
                    break;
                }

            }
            if (isPrincessSaved)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {life}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            PrintMatrix(matrix);
        }



        private static bool IsInMatrix(int marioRow, int marioCol, char[][] matrix)
        {
            if (marioRow >= 0 && marioRow < matrix.GetLength(0)
                && marioCol >= 0 && marioCol < matrix[marioRow].Length)
            {
                return true;
            }
            return false;
        }
        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}