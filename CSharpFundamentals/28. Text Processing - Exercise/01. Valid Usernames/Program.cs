using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            const int MAX_CHARS_IN_USERNAME = 16;
            const int MIN_CHARS_IN_USERNAME = 3;
            List<string> correctUsernames = new List<string>();
            bool isCorrectUsername = true;

            foreach (var username in usernames)
            {
                if (username.Length <= MAX_CHARS_IN_USERNAME && username.Length >= MIN_CHARS_IN_USERNAME)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        char currChar = username[i];
                        if (!(currChar == '-' || currChar == '_' || char.IsLetterOrDigit(currChar)))
                        {
                            isCorrectUsername = false;
                            break;
                        }
                        else
                        {
                            isCorrectUsername = true;
                        }

                    }
                    if (isCorrectUsername)
                    {

                        correctUsernames.Add(username);
                    }

                }

            }
            foreach (var item in correctUsernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
