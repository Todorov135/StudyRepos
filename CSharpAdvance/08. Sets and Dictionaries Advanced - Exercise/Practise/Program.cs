using System;
using System.Collections.Generic;
using System.Linq;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                
                
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    string currClothe = clothes[j];
                    if (!wardrobe[color].ContainsKey(currClothe))
                    {
                        wardrobe[color].Add(currClothe, 0);
                    }
                    wardrobe[color][currClothe]++;
                }

            }
            string[] surchPattern = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if (surchPattern[0] == color.Key && surchPattern[1] == clothes.Key)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }

            
        }
    }
}
