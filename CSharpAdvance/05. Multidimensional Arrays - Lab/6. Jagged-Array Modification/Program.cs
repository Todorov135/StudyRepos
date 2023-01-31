using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
               
            }

            string cmd = Console.ReadLine();

            while (cmd != "END" )
            {
                string[] tokens = cmd.Split();
                int row = int.Parse(cmd.Split()[1]);
                int col = int.Parse(cmd.Split()[2]);
                int value = int.Parse(cmd.Split()[3]);

                if (!(row >= 0 
                    && row < rows
                    && col >= 0
                    && col < jaggedArr[row].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                    cmd = Console.ReadLine();
                    continue;

                }

                if (cmd.StartsWith("Add"))
                {
                    jaggedArr[row][col] = jaggedArr[row][col] + value;
                }
                else if (cmd.StartsWith("Subtract"))
                {
                    jaggedArr[row][col] = jaggedArr[row][col] - value;
                }
                cmd = Console.ReadLine();
            }
            foreach (var item in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            
        }
    }
}
