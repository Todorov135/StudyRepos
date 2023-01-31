using System;

namespace FriendList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            int blacklistedCounter = 0;
            int lostCounter = 0;

            while (command != "Report")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Blacklist")
                {


                    for (int i = 0; i < nameArr.Length; i++)
                    {
                        if (tokens[1] == nameArr[i])
                        {
                            nameArr[i] = "Blacklisted";
                            Console.WriteLine($"{tokens[1]} was blacklisted.");
                            blacklistedCounter++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{tokens[1]} was not found.");
                            break;
                        }
                    }

                }
                else if (tokens[0] == "Error")
                {
                    int index = int.Parse(tokens[1]);
                    for (int i = 0; i < nameArr.Length; i++)
                    {
                        if (index >= 0 && index <= nameArr.Length - 1 && nameArr[index] != "Blacklisted" && nameArr[index] != "Lost")
                        {
                            Console.WriteLine($"{nameArr[index]} was lost due to an error.");
                            nameArr[index] = "Lost";
                            lostCounter++;
                            break;
                        }

                    }

                }
                else if (tokens[0] == "Change")
                {
                    int index = int.Parse(tokens[1]);
                    string newName = tokens[2];
                    if (index >= 0 && index <= nameArr.Length - 1)
                    {
                        for (int i = 0; i < nameArr.Length; i++)
                        {
                            if (nameArr[i] == nameArr[index] && nameArr[i] != newName)
                            {
                                Console.WriteLine($"{nameArr[index]} changed his username to {newName}.");
                                nameArr[i] = newName;
                                break;
                            }
                        }
                    }

                }
                command = Console.ReadLine();

            }
            Console.WriteLine($"Blacklisted names: {blacklistedCounter}");
            Console.WriteLine($"Lost names: {lostCounter}");
            Console.WriteLine(string.Join(" ", nameArr));
        }
    }
}