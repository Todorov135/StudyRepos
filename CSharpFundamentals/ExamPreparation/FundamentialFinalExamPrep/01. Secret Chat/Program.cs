using System;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();
            string command = Console.ReadLine();
            
            while (command != "Reveal")
            {
                string[] tokens = command.Split(":|:");

                if (tokens[0] == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    concealedMessage = concealedMessage.Insert(index, " ");
                    Console.WriteLine(concealedMessage);
                }
                else if (tokens[0] == "Reverse")
                {
                    string substring = tokens[1];

                    if (concealedMessage.Contains(substring))
                    {
                        int startIndexOfSubstring = concealedMessage.IndexOf(substring);
                        concealedMessage = concealedMessage.Remove(startIndexOfSubstring, substring.Length);

                        concealedMessage = concealedMessage + string.Join("",substring.Reverse());
                        Console.WriteLine(concealedMessage);

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                

                }
                else if (tokens[0] == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacementSubstring = tokens[2];

                    concealedMessage = concealedMessage.Replace(substring,replacementSubstring);
                    Console.WriteLine(concealedMessage);
                }
                command = Console.ReadLine();

            }
            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
