using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> frinedsList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            List<string> blackList = new List<string>();
            int blackListedCounter = 0;
            List<string> lostList = new List<string>();
            int lostListedCounter = 0;

            
            while (command != "Report")
            {
             string[] tokens = command.Split();
                if (tokens[0] == "Blacklist")
                {
                    string blacklistedName = tokens[1];
                    if (!frinedsList.Contains(blacklistedName))
                    {
                        Console.WriteLine($"{blacklistedName} was not found.");
                        
                        
                    }
                    else
                    {

                    blackList.Add(blacklistedName);
                    blackListedCounter++;
                    Console.WriteLine($"{blacklistedName} was blacklisted.");
                    int indexCounter = 0;
                    for (int i = 0; i < frinedsList.Count; i++)
                    {
                        if (frinedsList[i] == blacklistedName)
                        {
                            break;
                        }
                        indexCounter++;
                    }
                    frinedsList.RemoveAt(indexCounter);
                    string insert = "Blacklisted";
                    frinedsList.Insert(indexCounter, insert);
                    }



                }
                else if (tokens[0] == "Error")
                {
                    int index = int.Parse(tokens[1]);
                    if (frinedsList[index] == "Lost" )
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    if (index > 0 && index <= frinedsList.Count-1 && !blackList.Contains(frinedsList[index]) && !lostList.Contains(frinedsList[index]))
                    {
                        lostList.Add(frinedsList[index]);
                        Console.WriteLine($"{frinedsList[index]} was lost due to an error.");
                        frinedsList.RemoveAt(index);
                         lostListedCounter++;
                        frinedsList.Insert(index, "Lost");
                    }
                    
                }
                else if (tokens[0] == "Change")
                {
                    int index = int.Parse(tokens[1]);
                    string newName = tokens[2];

                    if (index >= 0 && index <= frinedsList.Count - 1 && !blackList.Contains(frinedsList[index]) && !lostList.Contains(frinedsList[index]))
                    {
                        Console.WriteLine($"{frinedsList[index]} changed his username to {newName}.");
                        frinedsList[index] = newName;
                    }
                    

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blackListedCounter}");
            Console.WriteLine($"Lost names: {lostListedCounter}");
            Console.WriteLine(string.Join(" ", frinedsList));
        }
    }
}
