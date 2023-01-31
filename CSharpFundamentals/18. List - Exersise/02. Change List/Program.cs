using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] manipulatingCommand = Console.ReadLine().Split();

            while (manipulatingCommand[0] != "end")
            {
                if (manipulatingCommand[0] == "Delete")
                {
                    int element = int.Parse(manipulatingCommand[1]);
                    input.RemoveAll(el => el == element);
                }
                else
                {
                    int element = int.Parse(manipulatingCommand[1]);
                    int position = int.Parse(manipulatingCommand[2]);
                    input.Insert(position, element);
                }
                manipulatingCommand = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", input));
        }
    }
}
