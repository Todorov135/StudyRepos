using System;
using System.Linq;
using System.Text;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();
            string password = inputPassword;
            string command = Console.ReadLine();
            StringBuilder newPass = new StringBuilder();

            while (command != "Done")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "TakeOdd")
                {
                    for (int i = 0; i < password.Length; i++)
                    {    
                        if (i % 2 != 0)
                        {
                            newPass.Append(password[i]);
                        }
                    }
                    password = newPass.ToString();
                    Console.WriteLine(password);

                }
                else if (action == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string substring = tokens[1];
                    string substitute = tokens[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }

                }
                
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
