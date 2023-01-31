using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                if (command[0] == "Add")
                {
                    if (deck.Contains(command[1]))
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                    else
                    {
                        deck.Add(command[1]);
                        Console.WriteLine("Card successfully added");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (!deck.Contains(command[1]))
                    {
                        Console.WriteLine("Card not found");
                    }
                    else
                    {
                        deck.Remove(command[1]);
                        Console.WriteLine("Card successfully removed");
                    }

                }
                else if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);
                    if (index < 0 || index > deck.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }
                    else
                    {
                        deck.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }

                }

                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string cardName = command[2];
                    if (index < 0 || index > deck.Count-1)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }
                    if (index >=0 && index <= deck.Count-1 && deck.Contains(cardName))
                    {
                        Console.WriteLine("Card is already added");
                    }
                    else
                    {
                        deck.Insert(index, cardName);
                        Console.WriteLine("Card successfully added");
                    }
                    
                }


            }
            Console.WriteLine(String.Join(", ", deck));
        }
    }
}
