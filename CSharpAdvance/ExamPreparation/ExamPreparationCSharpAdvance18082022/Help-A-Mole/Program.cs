using System;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int PointsToCollect = 25;
            const int RemovingPoints = 3;

            int size = int.Parse(Console.ReadLine());

            int moleRow = 0;
            int moleCol = 0;

            int collectedPoints = 0;
            bool isMoleCollect = false;

            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string lines = Console.ReadLine();
                for (int  col = 0;  col < matrix.GetLength(1);  col++)
                {
                    matrix[row, col] = lines[col];
                    if (matrix[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }
            matrix[moleRow, moleCol] = '-';
            string cmd = "";
            while ((cmd = Console.ReadLine()) != "End" && collectedPoints< PointsToCollect)
            {
                int oldPossitionRow = moleRow;
                int oldPossitionCol = moleCol;
                switch (cmd)
                {
                    case "up":
                        moleRow--;
                        break;
                    case "down":
                        moleRow++;
                        break;
                    case "left":
                        moleCol--;
                        break;
                    case "right":
                        moleCol++;
                        break;
                }
                if (!IsValidPossition(moleRow, moleCol, matrix))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    moleRow = oldPossitionRow;
                    moleCol = oldPossitionCol;
                    continue;
                }
                if (char.IsDigit(matrix[moleRow, moleCol]))
                {
                    string currDigit = matrix[moleRow, moleCol].ToString();
                    int numberToAdd = int.Parse(currDigit);
                    collectedPoints += numberToAdd;
                    if (collectedPoints >= PointsToCollect)
                    {
                        isMoleCollect = true;
                    }
                    matrix[moleRow, moleCol] = '-';
                }
                if (matrix[moleRow, moleCol] == 'S')
                {
                    collectedPoints -= RemovingPoints;
                    matrix[moleRow, moleCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'S')
                            {
                                moleRow = row;
                                moleCol = col;
                            }
                        }
                    }
                    matrix[moleRow, moleCol] = '-';
                }
            }
            matrix[moleRow, moleCol] = 'M';
            if (isMoleCollect)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {collectedPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {collectedPoints} points.");
            }
            PrintMatrix(matrix);
        }

        

        private static bool IsValidPossition(int moleRow, int moleCol, char[,] matrix)
        {
            if (moleRow >= 0 && moleRow < matrix.GetLength(0)
                && moleCol >= 0 && moleCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
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
