using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Queue<int> orderQueue = new Queue<int>(orders);
            Console.WriteLine(orderQueue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                if (foodQuantity >= orderQueue.Peek())
                {
                    foodQuantity -= orderQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orderQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else 
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orderQueue)}");
            }

        }
    }
}
