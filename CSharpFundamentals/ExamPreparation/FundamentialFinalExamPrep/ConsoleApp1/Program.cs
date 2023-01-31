using System;
using System.Linq;
using System.Text;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            string password = "";
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] splitted = command.Split(' ');

                string action = splitted[0];

                if (action == "TakeOdd")
                {
                    for (int i = 1; i < text.Length; i += 2)
                    {
                        sb.Append(text[i]);

                    }

                    Console.WriteLine(sb.ToString());

                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int lenght = int.Parse(splitted[2]);
                    int test = startIndex + lenght;

                    if (test > password.Length)
                    {
                        continue;
                    }
                    sb.Remove(startIndex, lenght);


                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string chReplace = splitted[1];
                    string newChar = splitted[2];

                    if (password.Contains(chReplace))
                    {
                        sb.Replace(chReplace, newChar);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                password = sb.ToString();
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}