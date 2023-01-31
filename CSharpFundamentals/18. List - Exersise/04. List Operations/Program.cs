using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                
                if (command[0] == "Add") 
                {
                    int number = int.Parse(command[1]);
                    input.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index > input.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        
                    }
                    input.Insert(index, number);
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index > input.Count-1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                       
                    }
                    input.Remove(input[index]);
                }
                else if (command[1] == "left")
                {
                    int countOfShifting = int.Parse(command[2]);

                    for (int i = 0; i < countOfShifting; i++)
                    {
                        input.Add(input[0]);
                        input.RemoveAt(0);
                    }
                }
                else if (command[1] == "right")
                {
                    int countOfShifting = int.Parse(command[2]);
                    for (int i = 0; i < countOfShifting; i++)
                    {
                        input.Insert(0, input[input.Count - 1]);
                        input.RemoveAt(input.Count - 1);
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", input));
        }
    }
}
