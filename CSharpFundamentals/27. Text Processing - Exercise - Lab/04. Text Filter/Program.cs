using System;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToBan = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string textToManipulating = Console.ReadLine();

            foreach (var word in wordsToBan)
            {
                string stringToReverce = new string('*', word.Length);
                textToManipulating = textToManipulating.Replace(word, stringToReverce);

            }
            Console.WriteLine(textToManipulating);
        }
    }
}
