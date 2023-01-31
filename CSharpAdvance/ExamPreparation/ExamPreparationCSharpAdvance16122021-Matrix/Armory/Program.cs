using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int KingAdvance = 65;

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int officerRow = 0;
            int officerCol = 0;
            int spendedGold = 0;
            bool isOutFromMatrix = false;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }
            int oldOfficerPossitionRow;
            int oldOfficerPossitionCol;
            matrix[officerRow, officerCol] = '-';
            while (true)
            {

                string cmd = Console.ReadLine();
                oldOfficerPossitionRow = officerRow;
                oldOfficerPossitionCol = officerCol;
                switch (cmd)
                {
                    case "up":
                        officerRow--;
                        break;
                    case "down":
                        officerRow++;
                        break;
                    case "left":
                        officerCol--;
                        break;
                    case "right":
                        officerCol++;
                        break;
                }
                if (!IsValidCell(officerRow, officerCol, matrix))
                {
                    isOutFromMatrix = true;
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                if (char.IsDigit(matrix[officerRow, officerCol]))
                {
                    string currChar = matrix[officerRow, officerCol].ToString();
                    int swordPrice = int.Parse(currChar);

                    spendedGold += swordPrice;
                    matrix[officerRow, officerCol] = '-';
                    if (spendedGold >= KingAdvance)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }

                if (matrix[officerRow, officerCol] == 'M')
                {
                    matrix[officerRow, officerCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            
                            if (matrix[row, col] == 'M')
                            {
                                officerRow = row;
                                officerCol = col;
                            }


                        }
                    }
                    matrix[officerRow, officerCol] = '-';
                }
                


            }
            if (isOutFromMatrix)
            {
                officerRow = oldOfficerPossitionRow;
                officerCol = oldOfficerPossitionCol;
                matrix[officerRow, officerCol] = '-';
            }
            else
            {
                matrix[officerRow, officerCol] = 'A';

            }


            Console.WriteLine($"The king paid {spendedGold} gold coins.");
            PrintMatrix(matrix);

        }



        private static bool IsValidCell(int officerRow, int officerCol, char[,] matrix)
        {
            if (officerRow >= 0 && officerRow < matrix.GetLength(0)
                && officerCol >= 0 && officerCol < matrix.GetLength(1))
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
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
