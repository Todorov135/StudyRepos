using System;

namespace Bee
{
    internal class Bee
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            int flowers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            string cmd = "";
            
            while ((cmd = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow = MoveUpDown(beeRow, cmd);
                beeCol = MoveLeftRight(beeCol, cmd);
                if (!IsValid(beeRow, beeCol, matrix))
                {
                    Console.WriteLine($"The bee got lost!");
                    break;
                    
                }
                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }
                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveUpDown(beeRow, cmd);
                    beeCol = MoveLeftRight(beeCol, cmd);
                    if (!IsValid(beeRow, beeCol, matrix))
                    {
                        Console.WriteLine($"The bee got lost!");
                        break;

                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                }
                matrix[beeRow, beeCol] = 'B';
               
               
            }
            if (flowers<5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }



        public static int MoveUpDown(int beeRow, string cmd)
        {
            if (cmd == "up")
            {
                return beeRow-1;
            }
            if (cmd == "down")
            {
                return beeRow+1;
            }
            return beeRow;
        }
        public static int MoveLeftRight(int beeCol, string cmd)
        {
            if (cmd == "left")
            {
                return beeCol-1;
            }
            if (cmd == "right")
            {
                return beeCol+1;
            }
            return beeCol;
        }
        public static bool IsValid(int beeRow, int beeCol, char[,] matrix)
        {
            if (beeRow >= 0 && beeRow < matrix.GetLength(0)
                && beeCol >= 0 && beeCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }

}

