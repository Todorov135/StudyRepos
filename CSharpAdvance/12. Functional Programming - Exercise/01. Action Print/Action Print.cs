using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            Action<string> actionPrint = n => Console.WriteLine(n);

            foreach (string name in input)
            {
                actionPrint(name);
            }
        }
    }
}
