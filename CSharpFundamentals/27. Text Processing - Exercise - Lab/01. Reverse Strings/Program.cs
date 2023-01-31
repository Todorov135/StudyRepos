using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputedWord = "";

            while ((inputedWord=Console.ReadLine()) != "end")
            {
                string reverceWord = "";
                for (int i = inputedWord.Length-1; i >= 0; i--)
                {
                    reverceWord += inputedWord[i];

                }
                Console.WriteLine($"{inputedWord} = {reverceWord}");

            }
        }
    }
}
