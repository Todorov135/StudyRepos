using System;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputSetLenght = Console.ReadLine();

            int n = int.Parse(inputSetLenght.Split()[0]);
            int m = int.Parse(inputSetLenght.Split()[1]);
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();


            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                set1.Add(input);
            }
            for (int i = 0; i < m; i++)
            {
                int input = int.Parse(Console.ReadLine());
                set2.Add(input);
            }
            set1.IntersectWith(set2);
            foreach (var item in set1)
            {
                Console.Write(item + " ");
            }
        }
    }
}
