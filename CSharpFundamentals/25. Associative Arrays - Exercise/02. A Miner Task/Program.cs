using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resources = Console.ReadLine();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            while (resources != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!keyValuePairs.ContainsKey(resources))
                {
                    keyValuePairs.Add(resources, quantity);
                }
                else
                {
                    keyValuePairs[resources] += quantity;

                }

                resources = Console.ReadLine();
            }

            foreach (var resource in keyValuePairs)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
