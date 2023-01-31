using System;
using System.Collections.Generic;

namespace Boxes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < lines; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            var box = new Box<double>(list);
            double compareor = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CounterElements(list, compareor));

        }
    }
}
