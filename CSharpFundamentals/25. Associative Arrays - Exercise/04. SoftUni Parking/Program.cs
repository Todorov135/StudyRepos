using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, string> nameAndLicensePlateNumber = new Dictionary<string, string>();

            for (int i = 0; i < lines; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmd[0];
                string userName = cmd[1];

                if (action == "register")
                {
                    string licensePlateNumber = cmd[2];
                    if (!nameAndLicensePlateNumber.ContainsKey(userName))
                    {
                        nameAndLicensePlateNumber.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        continue;
                    }

                }
                else if (action == "unregister")
                {
                    if (!nameAndLicensePlateNumber.ContainsKey(userName))
                    {
                        
                        Console.WriteLine($"ERROR: user {userName} not found"); //404
                    }
                    else
                    {
                        nameAndLicensePlateNumber.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");

                    }

                }

            }

            foreach (var user in nameAndLicensePlateNumber)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
            
        }
    }
}
