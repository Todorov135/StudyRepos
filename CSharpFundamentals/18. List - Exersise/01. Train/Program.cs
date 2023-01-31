using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] token = command.Split();
                if (token[0] == "Add")
                {
                    int newWahon = int.Parse(token[1]);
                    wagons.Add(newWahon);
                }
                else
                {
                    int passingers = int.Parse(token[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currWagon = wagons[i];    
                        if (currWagon + passingers <= maxCapacity)
                        {
                            wagons[i] += passingers;
                            break;
                        }

                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));

        }
    }
}
