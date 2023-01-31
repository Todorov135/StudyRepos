using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elemetsToSplit = { ", ", " " };
                string[] tokens = input.Split(elemetsToSplit, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Push")
                {
                    int[] elementsToAdd = tokens.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(elementsToAdd);
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }
            
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var number in stack)
                {
                    Console.WriteLine(number);
                }
            }


            
        }
    }
}
