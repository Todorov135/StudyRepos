using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> bombFeild = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = bombArr[0];
            int power = bombArr[1];

            for (int i = 0; i < bombFeild.Count; i++)
            {
                int currNum = bombFeild[i];
                if (currNum == bomb)
                {
                    
                    int startingDetonation = Math.Max(0, i - power);
                    int endingDetonation = Math.Min(bombFeild.Count-1, i + power);

                    for (int j = startingDetonation; j <= endingDetonation; j++)
                    {
                        bombFeild[j] = 0;
                    }
                }
            }
            Console.WriteLine(bombFeild.Sum());
        }
    }
}
