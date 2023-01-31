using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);
            }

            int[] swapPosisions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var box = new Box<int>(list);
            box.Swap(swapPosisions[0], swapPosisions[1]);
            Console.WriteLine(box);
        }
    }
}
