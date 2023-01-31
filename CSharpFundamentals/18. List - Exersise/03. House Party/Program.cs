using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int numOfCommands = int.Parse(Console.ReadLine());
            List<string> listOfGeusts= new List<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] nameAndType = Console.ReadLine().Split();

                if (!listOfGeusts.Contains(nameAndType[0])&& nameAndType[2]=="going!")
                {
                    listOfGeusts.Add(nameAndType[0]);
                }
                else if (listOfGeusts.Contains(nameAndType[0]) && nameAndType[2] == "going!")
                {
                    Console.WriteLine($"{nameAndType[0]} is already in the list!");
                }
                else if (listOfGeusts.Contains(nameAndType[0]) && nameAndType[2] == "not")
                {
                    listOfGeusts.Remove(nameAndType[0]);
                }
                else if (!listOfGeusts.Contains(nameAndType[0]) && nameAndType[2] == "not")
                {
                    Console.WriteLine($"{nameAndType[0]} is not in the list!");
                }
            }
            foreach (var names in listOfGeusts)
            {
                Console.WriteLine(names);
            }
        }
    }
}
